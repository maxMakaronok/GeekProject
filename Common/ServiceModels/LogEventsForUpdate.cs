using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    [DataContract]
    public class LogEventsForUpdate
    {
        [DataMember]
        public int EventId { get; set; }

        [DataMember]
        public string Name{ get; set; }

        [DataMember]
        public bool IsEnable { get; set; }
    }
}
