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
using ServiceModels.Extensions;
using ServiceModels.RolesAndTasks;

namespace CoreService
{
    public class UsersService : IUsersService
    {
        private readonly GeekEntities _database;
        public UsersService()
        {
            _database=new GeekEntities();
        }
        ~UsersService()
        {
            //закрываем соединение с базой
            _database.Dispose();
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
            var cachName = CacheNameManager.Core_UserRoles.GetEnumText() + userId;
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
            var cachName = CacheNameManager.Core_UserTasks.GetEnumText() + userId;
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

        public bool IsUserInRole(int userId, RolesEnum role)
        {
            return IsUserInRoles(userId, new List<RolesEnum>()
                                             {
                                                 role
                                             });
        }

        public bool IsUserInRoles(int userId, List<RolesEnum> roles)
        {
            var userRoles = GetUserRoles(userId).Select(p=>p.RoleId).ToArray();
            //имеет хотя бы одну роль из перечисленных
            return  roles.Any(role => userRoles.Contains(role.GetEnumValue()));
        }

        public bool IsTaskAllowForUser(int userId, TasksEnum task)
        {
            return IsTasksAllowForUser(userId, new List<TasksEnum>()
                                             {
                                                 task
                                             });
        }

        public bool IsTasksAllowForUser(int userId, List<TasksEnum> tasks)
        {
            var userTasks = GetUserTasks(userId).Select(p => p.TaskId).ToArray();
            //имеет хотя бы одну роль из перечисленных
            return tasks.Any(task => userTasks.Contains(task.GetEnumValue()));
        }

        public void UpdateUserRolesAndTask(int userId,List<int> newRoles, List<int> newTasks)
        {
            if (newRoles.Any())
            {
                var oldRoles = GetUserRoles(userId).Select(p=>p.RoleId).ToArray();
                CacheHelper.RemoveCacheElement(CacheNameManager.Core_UserRoles.GetEnumText()+userId);

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
                CacheHelper.RemoveCacheElement(CacheNameManager.Core_UserTasks.GetEnumText() + userId);

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
