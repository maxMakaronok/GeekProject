using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace ServiceModels
{
    /// <summary>
    /// Сообщения для логирования
    /// </summary>
    [DataContract]
    public class LogAddMessage
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [DataMember]
        public  string Message { get; set; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        [DataMember]
        public  int EventType { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        [DataMember]
        public  int ServiceId { get; set; }

        /// <summary>
        /// Путь к фалу с логами
        /// </summary>
        [DataMember]
        public string LogPath { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [DataMember]
        public int UserId { get; set; }
    }
}
