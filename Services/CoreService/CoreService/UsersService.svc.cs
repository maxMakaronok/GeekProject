using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CacheManager;
using Database;
using EnumExtensions;
using Enums.Security;
using Helper;
using LogServiceProxy.LogService;
using ServiceModels;
using ServiceModels.Extensions;
using ServiceModels.RolesAndTasks;
using Error = ServiceModels.Error;

namespace CoreService
{
    public class UsersService : IUsersService
    {
        private readonly GeekEntities _database;
        private readonly LogServiceClient _logClient;


        public UsersService()
        {
            _database=new GeekEntities();
            _logClient = new LogServiceClient();
        }
        ~UsersService()
        {
            _database.Dispose();
            try
            {
                _logClient.Close();
            }
            catch (Exception)
            {
               _logClient.Abort();
            }
        }
        
        public List<TaskModel> GetAllTasks()
        {
            var tasks = CacheHelper.GetCacheElement<List<TaskModel>>(CacheNameManager.Core_AllTasks);

            if (!tasks.ReturnSuccess())
            {
               tasks= _database.Tasks.ToArray().ToTaskModelList();
               CacheHelper.SetCacheElement(CacheNameManager.Core_AllTasks, tasks,120);
            }
            return tasks;
        }

        public List<RoleModel> GetAllRoles()
        {
            var roles = CacheHelper.GetCacheElement<List<RoleModel>>(CacheNameManager.Core_AllRoles);

            if (!roles.ReturnSuccess())
            {
                roles = _database.Roles.ToArray().ToRoleModelList();
                CacheHelper.SetCacheElement(CacheNameManager.Core_AllRoles, roles, 120);
            }
            return roles;
        }

        public List<RoleTasksModel> GetAllRoleTasks()
        {
            var roleTasks = CacheHelper.GetCacheElement<List<RoleTasksModel>>(CacheNameManager.Core_AllRoleTasks);
            if (!roleTasks.ReturnSuccess())
            {
                var rolesGroups = _database.RoleTasks.GroupBy(p => p.Role).ToArray();
                roleTasks= rolesGroups.Select(rolesGroup => new RoleTasksModel()
                                                                {
                                                                    Role = rolesGroup.Key.ToRoleModel(), 
                                                                    Tasks = rolesGroup.Select(p => p.Task).ToArray()
                                                                                      .ToTaskModelList()
                                                                }).ToList();

                CacheHelper.SetCacheElement(CacheNameManager.Core_AllRoleTasks, roleTasks, 120);
            }
            return roleTasks;
        }

        public List<RoleModel> GetUserRoles(int userId)
        {
            var cachName = CacheNameManager.Common_UserRoles.GetEnumText() + userId;
            var roles = CacheHelper.GetCacheElement<List<RoleModel>>(cachName);

            if (!roles.ReturnSuccess())
            {
                roles = _database.UserRoles.Where(p => p.UserId == userId)
                                           .Select(p => p.Role)
                                           .ToArray()
                                           .ToRoleModelList();
                CacheHelper.SetCacheElement(cachName, roles);
            }
            return roles;
        }

        public List<TaskModel> GetUserTasks(int userId)
        {
            var cachName = CacheNameManager.Common_UserTasks.GetEnumText() + userId;
            var tasks = CacheHelper.GetCacheElement<List<TaskModel>>(cachName);

            if (!tasks.ReturnSuccess())
            {
                tasks = _database.UserTasks.Where(p => p.UserId == userId)
                                           .Select(p => p.Task)
                                           .ToArray()
                                           .ToTaskModelList();
                CacheHelper.SetCacheElement(cachName, tasks);
            }
            return tasks;
        }

        public bool IsUserInRole(int userId, int role)
        {
            return IsUserInRoles(userId, new List<int>()
                                             {
                                                 role
                                             });
        }

        public bool IsUserWithLoginInRole(string login, int role)
        {
            var user = _database.Users.FirstOrDefault(p => p.Login == login || p.Email == login);
            return user != null && IsUserInRole(user.UserId, role);
        }

        public bool IsUserInRoles(int userId, List<int> roles)
        {
            var userRoles = GetUserRoles(userId).Select(p=>p.RoleId).ToArray();
            //имеет хотя бы одну роль из перечисленных
            return  roles.Any(userRoles.Contains);
        }

        public bool IsTaskAllowForUser(int userId, int task)
        {
            return IsTasksAllowForUser(userId, new List<int>()
                                             {
                                                 task
                                             });
        }

        public bool IsTasksAllowForUser(int userId, List<int> tasks)
        {
            var userTasks = GetUserTasks(userId).Select(p => p.TaskId).ToArray();
            //имеет хотя бы одну роль из перечисленных
            return tasks.Any(userTasks.Contains);
        }

        public UserInfo GetUserInfoById(int userId)
        {
            var user = _database.Users.FirstOrDefault(p => p.UserId == userId);
            return user.ReturnSuccess() ? user.ToUserInfo() : null;
        }

        public UserInfo GetUserInfoByLogin(string login)
        {
            var user = _database.Users.FirstOrDefault(p => p.Login == login || p.Email == login);
            return user.ReturnSuccess() ? user.ToUserInfo() : null;
        }

        public Error IsValid(string login, string password)
        {
            //придумать блоироку по айпи адресу если количество неверных запросов в день более 50
            var encryptedPassword = DataEncrypter.EncryptSha1(password);
            var user = _database.Users.FirstOrDefault(p => (p.Login == login || p.Email == login));

            if(!user.ReturnSuccess())
                return new Error { Code = 4, Message = "Неверный логин или e-mail" };

            if (user.Password != encryptedPassword)
            {
                user.ErrorPinCount = user.ErrorPinCount + 1;
                if (user.ErrorPinCount >= 5)
                {
                    user.IsBLocked = true;
                    user.BlockReason = "Пятикратная ошибка авторизации";
                    user.BlockDate = DateTime.Now;
                }
                _database.SaveChanges();

                return new Error { Code = 4, Message = "Неверные учетные данные" };
            }
            if (user.IsBLocked)
                return new Error { Code = 4, Message = string.Format("Пользователь заблокирован: {0}", user.BlockReason) };

            if (user.isDeleted)
                return new Error { Code = 4, Message = "Пользователь был удален из системы" };


            user.RegistrationDate = DateTime.Now;
            try
            {
                _database.SaveChanges();
            }
            catch (Exception)
            {
               //logi
                throw;
            }
            return Error.Ok;
        }

        public Error UpdateUserPersonalInfo(UserPersonalInfo newInfo)
        {
            var user = _database.Users.FirstOrDefault(p => p.UserId == newInfo.UserId);
            if (user.ReturnSuccess())
            {
                user.FirstName = newInfo.FirstName;
                user.LastName = newInfo.LastName;
                user.Login = user.Login;
                user.Password = DataEncrypter.EncryptSha1(newInfo.Password);

                try
                {
                    _database.SaveChanges();
                    return Error.Ok;
                }
                catch (Exception)
                {
                    return new Error(){Message = "Ошибка сохранения пользователя."};
                }
            }
            return new Error() { Message = "Ошибка сохранения пользователя. Пользователь отсутствует в системе" };
        }

        public Error RegistrateUser(string email)
        {
            //generate password
            var password = RandomGenerator.Generate();

            new User()
                {
                    Email = email,
                    Password = DataEncrypter.EncryptSha1(password),
                    RegistrationDate = DateTime.Now
                };

            try
            {
                _database.SaveChanges();
            }
            catch (Exception)
            {
              //log
                return new Error(){Message = "Ошибка создания пользователя"};
            }
            string err;
            MailSender.SendEmailMessage(email, "Zapis.by", "Password - > " + password, out err);
            if(!string.IsNullOrEmpty(err))
                return new Error() { Message = "Ошибка создания пользователя. Ошибка отправки на почту клиента" };

            //назначить роли и таски по умолчанию


            return Error.Ok;
        }

        public Error BlockUser(int userId, string reason)
        {
            var user = _database.Users.FirstOrDefault(p => p.UserId == userId);
            if (user.ReturnSuccess())
            {
                user.IsBLocked = true;
                user.BlockReason = reason;
                user.BlockDate = DateTime.Now;

                try
                {
                    _database.SaveChanges();
                }
                catch (Exception)
                {
                    return new Error() { Message = "Ошибка блокировки пользователя. Доступ к базе" };
                    throw;
                }
            }
            return new Error() { Message = "Ошибка блокировки пользователя. Пользователь отсутствует в системе" };
        }

        public Error UnBlockUser(int userId)
        {
            var user = _database.Users.FirstOrDefault(p => p.UserId == userId);
            if (user.ReturnSuccess())
            {
                user.IsBLocked = false;
                user.BlockReason = null;
                user.BlockDate =null;

                try
                {
                    _database.SaveChanges();
                }
                catch (Exception)
                {
                    return new Error() { Message = "Ошибка разблокировки пользователя. Доступ к базе" };
                    throw;
                }
            }
            return new Error() { Message = "Ошибка разблокировки пользователя. Пользователь отсутствует в системе" };
        }

        public Error DeleteUser(int userId)
        {
            var user = _database.Users.FirstOrDefault(p => p.UserId == userId);
            if (user.ReturnSuccess())
            {
                user.isDeleted = true;

                try
                {
                    _database.SaveChanges();
                }
                catch (Exception)
                {
                    return new Error() { Message = "Ошибка удаления пользователя. Доступ к базе" };
                    throw;
                }
            }
            return new Error() { Message = "Ошибка удаления пользователя. Пользователь отсутствует в системе" };
        }

        public void UpdateUserRolesAndTask(int userId,List<int> newRoles, List<int> newTasks)
        {
            if (newRoles.Any())
            {
                var oldRoles = GetUserRoles(userId).Select(p=>p.RoleId).ToArray();
                CacheHelper.RemoveCacheElement(CacheNameManager.Common_UserRoles.GetEnumText()+userId);

                var rolesIdToAdd = newRoles.Where(p => !oldRoles.Contains(p)).ToArray();
                var rolesIdToRemove = oldRoles.Where(p => !newRoles.Contains(p)).ToArray();

                var rolesToRemove = _database.UserRoles.Where(p => rolesIdToRemove.Contains(p.RoleId)).ToArray();

                foreach (var userRole in rolesToRemove)
                {
                    _database.UserRoles.Remove(userRole);
                }
                foreach (var userRole in rolesIdToAdd)
                {
                    _database.UserRoles.Add(new UserRole()
                                                {
                                                    UserId = userId,
                                                    RoleId = userRole
                                                });
                }
            }


            if (newTasks.Any())
            {
                var oldTasks = GetUserTasks(userId).Select(p => p.TaskId).ToArray();
                CacheHelper.RemoveCacheElement(CacheNameManager.Common_UserTasks.GetEnumText() + userId);

                var tasksIdToAdd = newTasks.Where(p => !oldTasks.Contains(p)).ToArray();
                var tasksIdToRemove = oldTasks.Where(p => !newTasks.Contains(p)).ToArray();

                var tasksToRemove = _database.UserTasks.Where(p => tasksIdToRemove.Contains(p.TaskId)).ToArray();

                foreach (var userTask in tasksToRemove)
                {
                    _database.UserTasks.Remove(userTask);
                }
                foreach (var userTask in tasksIdToAdd)
                {
                    _database.UserTasks.Add(new UserTask()
                    {
                        UserId = userId,
                        TaskId = userTask
                    });
                }
            }

            try
            {
                _database.SaveChanges();
            }
            catch (Exception){
                
                throw new Exception("обработать в лог");
            }
        }
    }
}
