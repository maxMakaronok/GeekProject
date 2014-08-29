using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels.RolesAndTasks
{
    [DataContract]
    public class RoleTasksModel
    {
        [DataMember]
        public RoleModel Role { get; set; }

        [DataMember]
        public List<TaskModel> Tasks { get; set; }
    }
}
