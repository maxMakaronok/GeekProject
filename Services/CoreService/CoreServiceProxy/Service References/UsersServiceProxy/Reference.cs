﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreServiceProxy.UsersServiceProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TaskModel", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels.RolesAndTasks")]
    [System.SerializableAttribute()]
    public partial class TaskModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TaskIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TaskId {
            get {
                return this.TaskIdField;
            }
            set {
                if ((this.TaskIdField.Equals(value) != true)) {
                    this.TaskIdField = value;
                    this.RaisePropertyChanged("TaskId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoleModel", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels.RolesAndTasks")]
    [System.SerializableAttribute()]
    public partial class RoleModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoleIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoleId {
            get {
                return this.RoleIdField;
            }
            set {
                if ((this.RoleIdField.Equals(value) != true)) {
                    this.RoleIdField = value;
                    this.RaisePropertyChanged("RoleId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoleTasksModel", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels.RolesAndTasks")]
    [System.SerializableAttribute()]
    public partial class RoleTasksModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CoreServiceProxy.UsersServiceProxy.RoleModel RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CoreServiceProxy.UsersServiceProxy.TaskModel[] TasksField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CoreServiceProxy.UsersServiceProxy.RoleModel Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CoreServiceProxy.UsersServiceProxy.TaskModel[] Tasks {
            get {
                return this.TasksField;
            }
            set {
                if ((object.ReferenceEquals(this.TasksField, value) != true)) {
                    this.TasksField = value;
                    this.RaisePropertyChanged("Tasks");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UsersServiceProxy.IUsersService")]
    public interface IUsersService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetAllTasks", ReplyAction="http://tempuri.org/IUsersService/GetAllTasksResponse")]
        CoreServiceProxy.UsersServiceProxy.TaskModel[] GetAllTasks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetAllTasks", ReplyAction="http://tempuri.org/IUsersService/GetAllTasksResponse")]
        System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.TaskModel[]> GetAllTasksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetAllRoles", ReplyAction="http://tempuri.org/IUsersService/GetAllRolesResponse")]
        CoreServiceProxy.UsersServiceProxy.RoleModel[] GetAllRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetAllRoles", ReplyAction="http://tempuri.org/IUsersService/GetAllRolesResponse")]
        System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.RoleModel[]> GetAllRolesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetAllRoleTasks", ReplyAction="http://tempuri.org/IUsersService/GetAllRoleTasksResponse")]
        CoreServiceProxy.UsersServiceProxy.RoleTasksModel[] GetAllRoleTasks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetAllRoleTasks", ReplyAction="http://tempuri.org/IUsersService/GetAllRoleTasksResponse")]
        System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.RoleTasksModel[]> GetAllRoleTasksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetUserRoles", ReplyAction="http://tempuri.org/IUsersService/GetUserRolesResponse")]
        CoreServiceProxy.UsersServiceProxy.RoleModel[] GetUserRoles(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetUserRoles", ReplyAction="http://tempuri.org/IUsersService/GetUserRolesResponse")]
        System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.RoleModel[]> GetUserRolesAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetUserTasks", ReplyAction="http://tempuri.org/IUsersService/GetUserTasksResponse")]
        CoreServiceProxy.UsersServiceProxy.TaskModel[] GetUserTasks(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetUserTasks", ReplyAction="http://tempuri.org/IUsersService/GetUserTasksResponse")]
        System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.TaskModel[]> GetUserTasksAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsUserInRole", ReplyAction="http://tempuri.org/IUsersService/IsUserInRoleResponse")]
        bool IsUserInRole(int userId, int role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsUserInRole", ReplyAction="http://tempuri.org/IUsersService/IsUserInRoleResponse")]
        System.Threading.Tasks.Task<bool> IsUserInRoleAsync(int userId, int role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsUserWithLoginInRole", ReplyAction="http://tempuri.org/IUsersService/IsUserWithLoginInRoleResponse")]
        bool IsUserWithLoginInRole(string login, int role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsUserWithLoginInRole", ReplyAction="http://tempuri.org/IUsersService/IsUserWithLoginInRoleResponse")]
        System.Threading.Tasks.Task<bool> IsUserWithLoginInRoleAsync(string login, int role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsUserInRoles", ReplyAction="http://tempuri.org/IUsersService/IsUserInRolesResponse")]
        bool IsUserInRoles(int userId, int[] roles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsUserInRoles", ReplyAction="http://tempuri.org/IUsersService/IsUserInRolesResponse")]
        System.Threading.Tasks.Task<bool> IsUserInRolesAsync(int userId, int[] roles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsTaskAllowForUser", ReplyAction="http://tempuri.org/IUsersService/IsTaskAllowForUserResponse")]
        bool IsTaskAllowForUser(int userId, int task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsTaskAllowForUser", ReplyAction="http://tempuri.org/IUsersService/IsTaskAllowForUserResponse")]
        System.Threading.Tasks.Task<bool> IsTaskAllowForUserAsync(int userId, int task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsTasksAllowForUser", ReplyAction="http://tempuri.org/IUsersService/IsTasksAllowForUserResponse")]
        bool IsTasksAllowForUser(int userId, int[] tasks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/IsTasksAllowForUser", ReplyAction="http://tempuri.org/IUsersService/IsTasksAllowForUserResponse")]
        System.Threading.Tasks.Task<bool> IsTasksAllowForUserAsync(int userId, int[] tasks);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsersServiceChannel : CoreServiceProxy.UsersServiceProxy.IUsersService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsersServiceClient : System.ServiceModel.ClientBase<CoreServiceProxy.UsersServiceProxy.IUsersService>, CoreServiceProxy.UsersServiceProxy.IUsersService {
        
        public UsersServiceClient() {
        }
        
        public UsersServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsersServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CoreServiceProxy.UsersServiceProxy.TaskModel[] GetAllTasks() {
            return base.Channel.GetAllTasks();
        }
        
        public System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.TaskModel[]> GetAllTasksAsync() {
            return base.Channel.GetAllTasksAsync();
        }
        
        public CoreServiceProxy.UsersServiceProxy.RoleModel[] GetAllRoles() {
            return base.Channel.GetAllRoles();
        }
        
        public System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.RoleModel[]> GetAllRolesAsync() {
            return base.Channel.GetAllRolesAsync();
        }
        
        public CoreServiceProxy.UsersServiceProxy.RoleTasksModel[] GetAllRoleTasks() {
            return base.Channel.GetAllRoleTasks();
        }
        
        public System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.RoleTasksModel[]> GetAllRoleTasksAsync() {
            return base.Channel.GetAllRoleTasksAsync();
        }
        
        public CoreServiceProxy.UsersServiceProxy.RoleModel[] GetUserRoles(int userId) {
            return base.Channel.GetUserRoles(userId);
        }
        
        public System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.RoleModel[]> GetUserRolesAsync(int userId) {
            return base.Channel.GetUserRolesAsync(userId);
        }
        
        public CoreServiceProxy.UsersServiceProxy.TaskModel[] GetUserTasks(int userId) {
            return base.Channel.GetUserTasks(userId);
        }
        
        public System.Threading.Tasks.Task<CoreServiceProxy.UsersServiceProxy.TaskModel[]> GetUserTasksAsync(int userId) {
            return base.Channel.GetUserTasksAsync(userId);
        }
        
        public bool IsUserInRole(int userId, int role) {
            return base.Channel.IsUserInRole(userId, role);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserInRoleAsync(int userId, int role) {
            return base.Channel.IsUserInRoleAsync(userId, role);
        }
        
        public bool IsUserWithLoginInRole(string login, int role) {
            return base.Channel.IsUserWithLoginInRole(login, role);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserWithLoginInRoleAsync(string login, int role) {
            return base.Channel.IsUserWithLoginInRoleAsync(login, role);
        }
        
        public bool IsUserInRoles(int userId, int[] roles) {
            return base.Channel.IsUserInRoles(userId, roles);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserInRolesAsync(int userId, int[] roles) {
            return base.Channel.IsUserInRolesAsync(userId, roles);
        }
        
        public bool IsTaskAllowForUser(int userId, int task) {
            return base.Channel.IsTaskAllowForUser(userId, task);
        }
        
        public System.Threading.Tasks.Task<bool> IsTaskAllowForUserAsync(int userId, int task) {
            return base.Channel.IsTaskAllowForUserAsync(userId, task);
        }
        
        public bool IsTasksAllowForUser(int userId, int[] tasks) {
            return base.Channel.IsTasksAllowForUser(userId, tasks);
        }
        
        public System.Threading.Tasks.Task<bool> IsTasksAllowForUserAsync(int userId, int[] tasks) {
            return base.Channel.IsTasksAllowForUserAsync(userId, tasks);
        }
    }
}
