//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.System_Logs = new HashSet<System_Logs>();
            this.UserRoles = new HashSet<UserRole>();
            this.UserTasks = new HashSet<UserTask>();
        }
    
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isDeleted { get; set; }
        public bool IsBLocked { get; set; }
        public Nullable<System.DateTime> BlockDate { get; set; }
        public string BlockReason { get; set; }
        public int ErrorPinCount { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public System.DateTime LastLoginDate { get; set; }
    
        public virtual ICollection<System_Logs> System_Logs { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
