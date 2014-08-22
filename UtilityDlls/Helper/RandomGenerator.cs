using System;

namespace Helper
{
    class RandomGenerator
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private const String CharArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
        private static Int32 _charCount = 6;
        
       /// <summary>
        /// Сгенерирует строку из n символов
       /// </summary>
       /// <param name="count">число символов</param>
       /// <returns></returns>
        public static String Generate(int count)
        {
            _charCount = count;
            return Generate();
        }
        /// <summary>
        /// Сгенерирует строку из 6 символов
        /// </summary>
        /// <returns></returns>
        public static String Generate()
        {
            var result = "";
            for (int i = 0; i < _charCount; i++)
            {
                var index = Random.Next(0, CharArray.Length);
                try
                {
                    result += CharArray[index];
                }
                catch (Exception)
                { }
            }
            return result;
        }
    }
    
}
