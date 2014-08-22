using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Linq;

namespace Logger
{
    public static class LogWriter
    {
        static DateTime _lastWrite = DateTime.MinValue;

        /// <summary>
        /// Ищет логи с датой последней записи старше текущего дня и архивирует GZip-ом.
        /// Вся эта шляпа делается в отдельном потоке.
        /// </summary>
        private static void RotateLogs(string logPath)
        {   
            new Thread(x =>
            {
                var mutex = new Mutex(false,
                                  Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(logPath))));
                mutex.WaitOne();
                try
                {
                    var logs = Directory.GetFiles(logPath, "*.log")
                        .Select(y => new FileInfo(y))
                        .Where(y => y.LastWriteTime.Date < DateTime.Now.Date);
                    foreach (var log in logs)
                    {
                        log.Compress();
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
                ).Start();
        }

        /// <summary>
        /// Запись в файл журнала сообщения
        /// </summary>
        /// <param name="message"> Текст сообщения</param>
        /// <param name="eventType"> Тип: ошибка, информация...</param>
        /// <param name="logPath"> Путь к папке для логирования</param>
        public static void Write(string message, TraceEventType eventType, string logPath = "")
        {
            var now = DateTime.Now;
            try
            {
                if (Directory.Exists(logPath) == false)
                    Directory.CreateDirectory(logPath);
            }
            catch (Exception)
            {
                return;
            }
           
             var   fileName = logPath + "\\" + now.ToString("yyyy.MM.dd") + ".log";
          
           

            var mutex = new Mutex(false,
                                  Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(fileName))));
            mutex.WaitOne();
            try
            {
                try
                {
                    using (var fs = new FileStream(fileName, FileMode.Append))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("[{0}]\t[{1}]\t[{2}]", now, eventType, message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }

            if (now.Date > _lastWrite.Date)
            {
                RotateLogs(logPath);
            }
            _lastWrite = now;
        }
    }
}
