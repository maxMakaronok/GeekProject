using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServiceModels.RolesAndTasks
{
    [DataContract]
    public class RoleModel
    {
        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

       
       
    }
}
