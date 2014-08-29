using System.Collections.Generic;
using System.ServiceModel;
using Enums.Security;
using ServiceModels.RolesAndTasks;

namespace CoreService
{
    
    [ServiceContract]
    public interface IUsersService
    {

        [OperationContract]
        List<TaskModel> GetAllTasks();

        [OperationContract]
        List<RoleModel> GetAllRoles();

        [OperationContract]
        List<RoleTasksModel> GetAllRoleTasks();

        [OperationContract]
        List<RoleModel> GetUserRoles(int userId);

        [OperationContract]
        List<TaskModel> GetUserTasks(int userId);


        #region Методы по хорошему надо перенести в web потому что это его задача допускать  или нет
        //хотя моджет оставить на случай если для мобилки будет влом писать))
        //или например какие нить внешние сервисы захотят дергать нас
      //короче оставляем но в webe продублировать надо будет чтоб напрасно запросы не шпулять на ядро

        [OperationContract]
        bool IsUserInRole(int userId, RolesEnum role);

        [OperationContract]
        bool IsUserInRoles(int userId, List<RolesEnum> roles);

        [OperationContract]
        bool IsTaskAllowForUser(int userId, TasksEnum task);

        [OperationContract]
        bool IsTasksAllowForUser(int userId, List<TasksEnum> tasks);

        #endregion

        
       
    }
}
