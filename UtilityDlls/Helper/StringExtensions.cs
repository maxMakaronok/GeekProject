using System;
using System.Text;

namespace Helper
{
    public static class StringExtensions
    {
        /// <summary>
        /// Переводит в строку
        /// </summary>
        /// <param name="o">в случае ошибки вернет пустую строку</param>
        /// <returns></returns>
        public static string ToStringWithValue(this object o)
        {
            return o == null ? String.Empty : o.ToString();
        }

        /// <summary>
        /// Переводит строку в число
        /// </summary>
        /// <param name="o">в случае ошибки вернет 0</param>
        /// <returns></returns>
        public static int ToInt(this string o)
        {
            var i = 0;

            int.TryParse(o, out i);

            return i;
        }

        /// <summary>
        /// Переводит строку в Base64
        /// </summary>
        /// <param name="toEncode"></param>
        /// <returns></returns>
        static public string EncodeTo64(this string toEncode)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            var returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        /// <summary>
        /// Пероводит строку из Base64
        /// </summary>
        /// <param name="encodedData"></param>
        /// <returns></returns>
        static public string DecodeFrom64(this string encodedData)
        {
            var encodedDataAsBytes = Convert.FromBase64String(encodedData);
            var returnValue = Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
