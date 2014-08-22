using System;

namespace EnumExtensions
{
    public class EnumValue : Attribute
    {
        public readonly int value;

        public EnumValue(int val)
        {
            value = val;
        }

        public int Value
        {
            get { return value; }
        }
    }
}
