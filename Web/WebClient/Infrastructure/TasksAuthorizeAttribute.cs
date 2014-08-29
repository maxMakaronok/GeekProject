using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CacheManager;
using CoreServiceProxy.UsersServiceProxy;
using EnumExtensions;
using Enums.Security;
using Helper;


namespace WebClient.Infrastructure
{
    public class TasksAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly List<int> _tasks;

        public TasksAuthorizeAttribute()
        {
            _tasks=new List<int>();
        }
       
        public TasksAuthorizeAttribute(params TasksEnum[] tasks)
        {
            _tasks =new List<int>();
            foreach (var tasksEnum in tasks)
            {
                _tasks.Add( tasksEnum.GetEnumValue());
            }
        }

        private int[] CurrentUserTasks
        {
            get
            {
                try
                {
                    var cachName = CacheNameManager.Common_UserTasks.GetEnumText() + CurrentUserId;
                    var tasks = CacheHelper.GetCacheElement<List<TaskModel>>(cachName);

                    if (!tasks.ReturnSuccess())
                    {
                        using (var client=new UsersServiceClient())
                        {
                            tasks = client.GetUserTasks(CurrentUserId).ToList();
                        }
                        CacheHelper.SetCacheElement(cachName, tasks);
                    }
                    return tasks.Select(p => p.TaskId).ToArray();

                }
                catch (Exception)
                {

                }

                return new int[] { };
            }
        }

        private int CurrentUserId { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isTasksAuthorised = false;

           


            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (filterContext.HttpContext != null && filterContext.HttpContext.Session["UserId"] != null)
                {
                    int userId = 0;
                    int.TryParse(filterContext.HttpContext.Session["UserId"].ToString(), out userId);
                    CurrentUserId = userId;

                    var currentUserTasks = CurrentUserTasks;

                    // Логика "ИЛИ": если пользователь имеет доступ хотя бы к одной задаче
                    foreach (var item in _tasks)
                    {
                        if (currentUserTasks.Contains(item))
                        {
                            isTasksAuthorised = true;
                            break;
                        }
                    }

                }

            }

            if (isTasksAuthorised || _tasks==null)
                base.OnAuthorization(filterContext);
            else
            {
                filterContext.Result = new RedirectResult("~/Login/Index");

            }

        }
    }
}