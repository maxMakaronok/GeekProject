using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using CacheManager;
using Database;
using Logger;
using ServiceModels;

namespace LogService
{
    public class LogService : ILogService
    {
        private readonly bool _enableFileLogger;
        private readonly bool _enableDBLogger;
        private readonly GeekEntities _database;

        public LogService()
        {
            _enableFileLogger = (ConfigurationManager.AppSettings["EnableFileLogger"] != null) && bool.Parse(ConfigurationManager.AppSettings["EnableFileLogger"]);
            _enableDBLogger = (ConfigurationManager.AppSettings["EnableDBLogger"] != null) && bool.Parse(ConfigurationManager.AppSettings["EnableDBLogger"]);
            _database = new GeekEntities();
        }
        ~LogService()
        {
            //закрываем соединение с базой
            _database.Dispose();
        }

        public void WriteLogMessage(LogMessage message)
        {
            #region  Достаем все события из кэша
            var logEvents = CacheHelper.GetCacheElement<List<System_LogEvents>>(CacheNameManager.Core_LogEventsList);
            if (logEvents == null)
            {
                //Если в кэше нету лезем за ними в базу

                try
                {
                    logEvents = _database.System_LogEvents.ToList();
                    CacheHelper.SetCacheElement(CacheNameManager.Core_LogEventsList, logEvents, 30);
                }
                catch (Exception)
                {
                }

            }
            #endregion

            var logEvent = logEvents.FirstOrDefault(p => p.Id == message.EventType);

            #region Работа с БД
            if (logEvent != null && logEvent.EnableLog && _enableDBLogger)
            {

                _database.System_Logs.Add(new System_Logs()
                    {
                        ServiceId = message.ServiceId,
                        EventId = logEvent.Id,
                        Message = message.Message,
                        EventDate = DateTime.Now,
                       // userid=message.UserId
                    });

                try
                {
                    _database.SaveChanges();
                }
                catch (Exception)
                {
                }


            }
            #endregion

            #region Работа с файлом
            if (logEvent != null && logEvent.EnableLog && _enableFileLogger)
            {
                var type = (logEvent.Id == 1) ? TraceEventType.Error : TraceEventType.Information;
                LogWriter.Write(message.Message, type, message.LogPath);
            }
            #endregion
        }

    }
}
