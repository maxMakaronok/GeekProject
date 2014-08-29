using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using ServiceModels.RolesAndTasks;

namespace ServiceModels.Extensions
{
    public static class SecurityExtensions
    {
        public static List<TaskModel>  ToTaskModelList(this IEnumerable<Task> tasks )
        {
            var taskModels = new List<TaskModel>();
            try
            {
                taskModels.AddRange(tasks.Select(tm => new TaskModel()
                {
                    TaskId = tm.TaskId,
                    Name = tm.Name,
                    Description = (!string.IsNullOrEmpty(tm.Description)) ? tm.Description : ""
                }));
            }
            catch 
            {
                
            }
            
            return taskModels;
        }

        public static List<RoleModel>  ToRoleModelList(this IEnumerable<Role> roles)
        {
            var roleModels = new List<RoleModel>();
            try
            {
                roleModels.AddRange(roles.Select(role => new RoleModel
                                                             {
                                                                 RoleId = role.RoleId,
                                                                 Name = role.Name,
                                                                 Description =
                                                                     (!string.IsNullOrEmpty(role.Description))
                                                                         ? role.Description
                                                                         : "",
                                                             }));
            }
            catch 
            {

            }
            return roleModels;

        }

        public static RoleModel ToRoleModel(this Role role)
        {
            return new RoleModel()
                       {
                           RoleId = role.RoleId,
                           Name = role.Name,
                           Description =
                               (!string.IsNullOrEmpty(role.Description))
                                   ? role.Description
                                   : "",
                       };
        }

        public static TaskModel ToTaskModel(this Task task)
        {
            return new TaskModel()
                       {
                           TaskId = task.TaskId,
                           Name = task.Name,
                           Description = (!string.IsNullOrEmpty(task.Description)) ? task.Description : ""
                       };
        }
    }
}
