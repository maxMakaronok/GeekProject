using System;

namespace EnumExtensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Получить текст из атрибута перечисления
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static String GetEnumText(this Enum e)
        {
            var type = e.GetType();

            var memberInfos = type.GetMember(e.ToString());

            if (memberInfos != null && memberInfos.Length > 0)
            {
                var attributes = memberInfos[0].GetCustomAttributes(typeof (EnumText),
                                                                    false);
                if (attributes != null && attributes.Length > 0)
                    return ((EnumText) attributes[0]).Value;
            }
            throw new ArgumentException("Enum " + e.ToString() + " has no EnumText defined!");
        }
        /// <summary>
        /// Получить значение из атрибута перечисления
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetEnumValue(this Enum e)
        {
            var type = e.GetType();

            var memberInfos = type.GetMember(e.ToString());

            if (memberInfos != null && memberInfos.Length > 0)
            {
                var attributes = memberInfos[0].GetCustomAttributes(typeof (EnumValue),
                                                                    false);
                if (attributes != null && attributes.Length > 0)
                    return ((EnumValue) attributes[0]).Value;
            }
            throw new ArgumentException("Enum " + e.ToString() + " has no EnumText defined!");
        }
    }
}
