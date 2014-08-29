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

        public void WriteLogMessage(LogAddMessage addMessage)
        {
            #region  Достаем все события из кэша
            var logEvents = CacheHelper.GetCacheElement<List<System_LogEvents>>(CacheNameManager.Log_LogEventsList);
            if (logEvents == null)
            {
                //Если в кэше нету лезем за ними в базу

                try
                {
                    logEvents = _database.System_LogEvents.ToList();
                    CacheHelper.SetCacheElement(CacheNameManager.Log_LogEventsList, logEvents, 30);
                }
                catch (Exception)
                {
                }

            }
            #endregion

            var logEvent = logEvents.FirstOrDefault(p => p.Id == addMessage.EventType);

            #region Работа с БД
            if (logEvent != null && logEvent.EnableLog && _enableDBLogger)
            {

                _database.System_Logs.Add(new System_Logs()
                    {
                        ServiceId = addMessage.ServiceId,
                        EventId = logEvent.Id,
                        Message = addMessage.Message,
                        EventDate = DateTime.Now,
                        UserId = addMessage.UserId
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
                LogWriter.Write(addMessage.Message, type, addMessage.LogPath);
            }
            #endregion
        }

        public List<LogGetMessage> GetLogs(LogFilter filter)
        {
            var messages = new List<LogGetMessage>();

            var systemLogs = _database.System_Logs.Select(p=>p);

            if (filter.EventId.HasValue)
                systemLogs=systemLogs.Where(p => p.EventId == filter.EventId.Value);

            if(filter.ServiceId.HasValue)
                systemLogs = systemLogs.Where(p => p.ServiceId == filter.ServiceId.Value);

            if (filter.EventDate.HasValue)
            {
                var startDate = filter.EventDate.Value;
                var endDate = startDate.AddDays(1);

                systemLogs = systemLogs.Where(p => p.EventDate>=startDate.Date &&
                                                   p.EventDate <= endDate.Date);
            }

            if (filter.Skip.HasValue)
                systemLogs = systemLogs.Skip(filter.Skip.Value);

            if (filter.Take.HasValue)
                systemLogs = systemLogs.Take(filter.Take.Value);

            try
            {
                messages.AddRange(systemLogs.Select(systemLog => new LogGetMessage
                {
                    ItemId = systemLog.Id,
                    EventName = systemLog.System_LogEvents.EventName,
                    EventDate = systemLog.EventDate,
                    ServiceName = systemLog.System_Services.Name,
                    Message = systemLog.Message,
                    UserLogin = systemLog.User.Email
                }));
            }
            catch
            {
               
            }
            return messages;
        }
    }
}
