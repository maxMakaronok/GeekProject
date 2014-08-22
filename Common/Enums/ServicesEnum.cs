using EnumExtensions;

namespace Enums
{
    public enum ServicesEnum
    {
        /// <summary>
        /// Ядро системы
        /// </summary>
        [EnumValue(1)]
        CoreService,
        
        /// <summary>
        /// Сайт
        /// </summary>
        [EnumValue(2)]
        WebService
    }
}
