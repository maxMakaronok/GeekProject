using System.Collections.Generic;
using System.ServiceModel;
using ServiceModels;

namespace LogService
{

    [ServiceContract]
    public interface ILogService
    {
        [OperationContract]
        void WriteLogMessage(LogAddMessage addMessage);

        [OperationContract]
        List<LogGetMessage> GetLogs(LogFilter filter);

        [OperationContract]
        Error UpdateLogEvents(IEnumerable<LogEventsForUpdate> events);

        [OperationContract]
        IEnumerable<LogEventsForUpdate> GetLogEvents();
    }


}
