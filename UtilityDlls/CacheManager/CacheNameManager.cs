using EnumExtensions;

namespace CacheManager
{
    /// <summary>
    /// Перечислитель для  работы с кэшам
    /// </summary>
    public enum CacheNameManager
    {
       #region LogService

        /// <summary>
        /// Список событий для логирования
        /// </summary>
        [EnumText("Core_LogEventsList")]
        Core_LogEventsList,

        #endregion
    }
}
