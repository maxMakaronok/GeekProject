using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.Security;
using CacheManager;
using CoreServiceProxy.UsersServiceProxy;
using EnumExtensions;
using Enums.Security;
using Helper;
using LogServiceProxy.LogService;

namespace WebClient.Infrastructure
{
    public class GeekController : Controller
    {
        #region System

        protected readonly LogServiceClient _logClient;
        protected readonly UsersServiceClient _usersClient;


        public GeekController()
        {
            _logClient = new LogServiceClient();
            _usersClient = new UsersServiceClient();

        }

        ~GeekController()
        {
            try
            {
                _logClient.Close();
                _usersClient.Close();
            }
            catch (Exception)
            {
                _logClient.Abort();
                _usersClient.Abort();
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated && Session["UserId"] == null)
            {
                FormsAuthentication.SignOut();
                Session.RemoveAll();
                filterContext.Result = new RedirectResult(Url.Action("Index", "Login", new { area = "" }));
                return;
            }

            base.OnActionExecuting(filterContext);

        }

        #endregion


        #region private

        private List<TaskModel> CurrentUserTasks
        {
            get
            {
                try
                {
                    var cachName = CacheNameManager.Common_UserTasks.GetEnumText() + CurrentUserId;
                    var tasks = CacheHelper.GetCacheElement<List<TaskModel>>(cachName);

                    if (!tasks.ReturnSuccess())
                    {
                        using (var client = new UsersServiceClient())
                        {
                            tasks = client.GetUserTasks(CurrentUserId).ToList();
                        }
                        CacheHelper.SetCacheElement(cachName, tasks);
                    }
                    return tasks;

                }
                catch (Exception)
                {

                }

                return new List<TaskModel>();
            }
        }

        private List<RoleModel> CurrentUserRoles
        {
            get
            {
                try
                {
                    var cachName = CacheNameManager.Common_UserRoles.GetEnumText() + CurrentUserId;
                    var tasks = CacheHelper.GetCacheElement<List<RoleModel>>(cachName);

                    if (!tasks.ReturnSuccess())
                    {
                        using (var client = new UsersServiceClient())
                        {
                            tasks = client.GetUserRoles(CurrentUserId).ToList();
                        }
                        CacheHelper.SetCacheElement(cachName, tasks);
                    }
                    return tasks;

                }
                catch (Exception)
                {

                }

                return new List<RoleModel>();
            }
        }

        private int CurrentUserId
        {
            get
            {
                try
                {
                    return int.Parse(Session["UserId"].ToStringWithValue());
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        #endregion


        public IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

        protected UserInfo CurrentUser
        {
            get
            {
                try
                {
                    var cachName = CacheNameManager.Web_CurrentUser.GetEnumText() + CurrentUserId;
                    var user = CacheHelper.GetCacheElement<UserInfo>(cachName);

                    if (!user.ReturnSuccess())
                    {
                        using (var client = new UsersServiceClient())
                        {
                            user = client.GetUserInfoById(CurrentUserId);
                        }
                        CacheHelper.SetCacheElement(cachName, user);
                    }
                    return user;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
      
        protected bool IsTaskAllowForUser(TasksEnum task)
        {
            return IsTaskAllowForUser(new[]
                                          {
                                              task
                                          });
        }

        protected bool IsTaskAllowForUser(params TasksEnum[] tasks)
        {
            var currentUserTasks = CurrentUserTasks.Select(p => p.TaskId).ToArray();
            return tasks.Any(task => currentUserTasks.Contains(task.GetEnumValue()));
        }

        protected void RemoveCurrentUserInfoCacheData()
        {
            try
            {
                CacheHelper.RemoveCacheElement(CacheNameManager.Common_UserTasks.GetEnumText() + CurrentUserId);
                CacheHelper.RemoveCacheElement(CacheNameManager.Common_UserRoles.GetEnumText() + CurrentUserId);
                CacheHelper.RemoveCacheElement(CacheNameManager.Web_CurrentUser.GetEnumText() + CurrentUserId);
            }
            catch (Exception)
            {

            }
        }
    }
}