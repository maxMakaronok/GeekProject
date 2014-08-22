using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Helper
{
    public class MailSender
    {
        /// <summary>
        /// Отправляет по указанному адресу сообщение используя конфигурацию приложения
        /// </summary>
        /// <param name="emailReceiver">От кого отправлять сообщение</param>
        /// <param name="messageTheme">Тема сообщения</param>
        /// <param name="messageBody">Текст сообщения</param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool SendEmailMessage(string emailReceiver, string messageTheme, string messageBody, out string error)
        {
            try
            {
                //TODO:Указываем настройки почтового сервера
                var client = new SmtpClient(ConfigurationManager.AppSettings["host"],
                                                   int.Parse(ConfigurationManager.AppSettings["port"]))
                {
                    Credentials = new MyCredentials()
                };

                //TODO:Формируем сообщение
                var message = new MailMessage
                {
                    Subject = messageTheme,
                    BodyEncoding = Encoding.UTF8,
                    From = new MailAddress(ConfigurationManager.AppSettings["userFrom"])
                };
                message.To.Add(new MailAddress(emailReceiver));
                message.Body = messageBody;

                client.SendAsync(message, null);
                error = "";
                return true;
            }
            catch (Exception ex)
            {
                error = string.Format("{0} {1} {2}", ex.Message, ex.InnerException, ex.StackTrace);
                return false;
            }
        }

    }

    public class MyCredentials : ICredentialsByHost
    {
        public NetworkCredential GetCredential(string host, int port, string authenticationType)
        {
            return new NetworkCredential(ConfigurationManager.AppSettings["userName"],
                                                                     ConfigurationManager.AppSettings["userPassword"]);
        }
    }
}
