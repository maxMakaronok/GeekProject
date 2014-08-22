using System.ServiceModel;
using ServiceModels;

namespace LogService
{
   
    [ServiceContract]
    public interface ILogService
    {
       [OperationContract]
        void WriteLogMessage(LogMessage message);
    }
    
  
}
