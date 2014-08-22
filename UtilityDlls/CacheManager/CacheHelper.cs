﻿using System;
using System.Configuration;
using System.Runtime.Caching;
using EnumExtensions;

namespace CacheManager
{
    public static class CacheHelper
    {

        /// <summary>
        /// Время жизни закэшированаго объекта
        /// </summary>
        private static readonly int DefaultExpired = (ConfigurationManager.AppSettings["DefaultExpiredMinuts"] == null)
                                                ? 5
                                                : int.Parse(ConfigurationManager.AppSettings["DefaultExpiredMinuts"]);
        /// <summary>
        /// Включен ли кэш
        /// </summary>
        private static readonly bool EnableCache = (ConfigurationManager.AppSettings["EnableCache"] != null) && bool.Parse(ConfigurationManager.AppSettings["EnableCache"]);

        /// <summary>
        /// Объект кэша .Net
        /// </summary>
        private static readonly ObjectCache Cache = MemoryCache.Default;



        #region Set
        /// <summary>
        /// Закэшировать объект на время
        /// </summary>
        /// <param name="name">Имя записи в кэше </param>
        /// <param name="obj"> Объект </param>
        /// <param name="minutesToExpired">Время жизни объекта в кэше</param>
        /// <returns> Закэширован ли объект</returns>
        public static bool SetCacheElement(string name, object obj, int minutesToExpired)
        {
            if (!EnableCache)
                return false;

            try
            {
                var dateTimeOffset = DateTimeOffset.Now.AddMinutes(minutesToExpired);
                return Cache.Add(name, obj, dateTimeOffset);
            }
            catch (Exception)
            {
                //если что то не так возвращаем ошибку 
                return false;
            }
        }

        /// <summary>
        /// Закэшировать объект
        /// </summary>
        /// <param name="name">Имя записи в кэше</param>
        /// <param name="obj">Объект</param>
        /// <returns>Закэширован ли объект</returns>
        public static bool SetCacheElement(string name, object obj)
        {
            return SetCacheElement(name, obj, DefaultExpired);
        }

        /// <summary>
        /// Закэшировать объект на время
        /// </summary>
        /// <param name="name">Перечислитель записи в кэше</param>
        /// <param name="obj">Объект</param>
        /// <param name="minutesToExpired">Время жизни объекта в кэше</param>
        /// <returns> Закэширован ли объект</returns>
        public static bool SetCacheElement(CacheNameManager name, object obj, int minutesToExpired)
        {
            var nameString = name.GetEnumText();
            return SetCacheElement(nameString, obj, minutesToExpired);
        }

        /// <summary>
        /// Закэшировать объект на время
        /// </summary>
        /// <param name="name">Перечислитель записи в кэше</param>
        /// <param name="obj">Объект</param>
        /// <returns> Закэширован ли объект</returns>
        public static bool SetCacheElement(CacheNameManager name, object obj)
        {
            return SetCacheElement(name, obj, DefaultExpired);
        }
        #endregion


        #region Get

        /// <summary>
        /// Достать объект из кэша
        /// </summary>
        /// <typeparam name="TResponce">тип объекта</typeparam>
        /// <param name="name">Имя записи в кэше</param>
        /// <returns>Объект или null если не содержится в кэше</returns>
        public static TResponce GetCacheElement<TResponce>(string name) where TResponce : class
        {
            try
            {
                var obj = Cache[name];
                //если не null то возвращаем приведенный обьект 
                return (obj == null) ? null : (TResponce)obj;
            }
            catch (Exception)
            {

                //если что то не так возвращаем ошибку 
                return null;
            }
        }


        /// <summary>
        /// Достать объект из кэша
        /// </summary>
        /// <typeparam name="TResponce">тип объекта</typeparam>
        /// <param name="name">Перечислитель записи в кэше</param>
        /// <returns>Объект или null если не содержится в кэше</returns>
        public static TResponce GetCacheElement<TResponce>(CacheNameManager name) where TResponce : class
        {
            var nameString = name.GetEnumText();
            return GetCacheElement<TResponce>(nameString);
        }
        #endregion
      
    }
}
