
using Enums;
using Logger;

namespace LogService
{
    public static class LogService
    {
        static async void WriteLog(string msg, LogEventsEnum eventType, ServicesEnum recipient = ServicesEnum.CoreService)
        {
            ///логика  для сохранения записи в бд





            //в файл пишем в любом случае
            LogWriter.Write();

        }

    }
}
