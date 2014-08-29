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
        [EnumText("Log_LogEventsList")]
        Log_LogEventsList,

        #endregion

        #region CoreService
        [EnumText("Core_AllTasks")]
        Core_AllTasks,

        [EnumText("Core_AllRoles")]
        Core_AllRoles,

        [EnumText("Core_AllRoleTasks")]
        Core_AllRoleTasks,

        [EnumText("Core_UserRoles")]
        Core_UserRoles,

        [EnumText("Core_UserTasks")]
        Core_UserTasks,

      
        #endregion

    }
}
