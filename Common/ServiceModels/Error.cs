using System.Runtime.Serialization;

namespace ServiceModels
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Message { get; set; }

        public static Error Ok
        {
            get { return new Error { Code = 0, Message = "OK" }; }
        }
    }
}
