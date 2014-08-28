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
    public class LogGetMessage
    {
        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string EventName { get; set; }
        
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public DateTime EventDate { get; set; }

        [DataMember]
        public string UserLogin { get; set; }
       
    }
}
