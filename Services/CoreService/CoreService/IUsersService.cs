using System.Collections.Generic;
using System.ServiceModel;
using Enums.Security;
using ServiceModels;
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

        [OperationContract]
        bool IsUserInRole(int userId, int role);

        [OperationContract]
        bool IsUserWithLoginInRole(string login, int role);

        [OperationContract]
        bool IsUserInRoles(int userId, List<int> roles);

        [OperationContract]
        bool IsTaskAllowForUser(int userId, int task);

        [OperationContract]
        bool IsTasksAllowForUser(int userId, List<int> tasks); 
        
        [OperationContract]
        UserInfo GetUserInfoById(int userId);

        [OperationContract]
        UserInfo GetUserInfoByLogin(string login);

        [OperationContract]
        Error IsValid(string login, string password);

        [OperationContract]
        Error UpdateUserPersonalInfo(UserPersonalInfo newInfo);

        [OperationContract]
        Error RegistrateUser(string email);

        [OperationContract]
        Error BlockUser(int userId, string reason);

        [OperationContract]
        Error UnBlockUser(int userId);

        [OperationContract]
        Error DeleteUser(int userId);





    }
}
