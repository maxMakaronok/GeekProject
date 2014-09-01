using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace ServiceModels
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool IsBLocked { get; set; }

        [DataMember]
        public DateTime? BlockDate { get; set; }

        [DataMember]
        public string BlockReason { get; set; }

        [DataMember]
        public int ErrorPinCount { get; set; }

        [DataMember]
        public DateTime RegistrationDate { get; set; }

        [DataMember]
        public DateTime LastLoginDate { get; set; }
        
    }

    [DataContract]
    public class UserPersonalInfo
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }
    }

 

    
}
