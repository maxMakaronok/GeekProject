using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    [DataContract]
    public class LogFilter
    {
        [DataMember]
        public int? EventId { get; set; }

        [DataMember]
        public int? ServiceId { get; set; }

        [DataMember]
        public DateTime? EventDate { get; set; }

        [DataMember]
        public int? Skip { get; set; }

        [DataMember]
        public int? Take { get; set; }

        [DataMember]
        public string Login { get; set; }

    }
}
