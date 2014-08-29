using System.Runtime.Serialization;

namespace ServiceModels.RolesAndTasks
{
    [DataContract]
    public class TaskModel
    {
        [DataMember]
        public int TaskId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
