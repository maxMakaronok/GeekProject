using System.Security.Cryptography;
using System.Text;

namespace Helper
{
    class DataEncrypter
    {
        /// <summary>
        /// Кодирует текст по формату Sha1
        /// </summary>
        /// <returns></returns>
        public static string EncryptSha1(string data)
        {
            var encoder = new UTF8Encoding();
            var hasher = new SHA1CryptoServiceProvider();
            var hashedDataBytes = hasher.ComputeHash(encoder.GetBytes(data));
            return ByteArrayToString(hashedDataBytes);
        }
      
        /// <summary>
        /// Перевод масиива байт в строку
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        private static string ByteArrayToString(byte[] inputArray)
        {
            var output = new StringBuilder("");
            for (var i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
}
