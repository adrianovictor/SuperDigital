using System;
using System.ComponentModel;
using System.Linq;

namespace SuperDigital.Common.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum objValue) where T : Attribute
        {
            var type = objValue.GetType();
            var field = type.GetField(objValue.ToString());

            return (T)field.GetCustomAttributes(true).FirstOrDefault(c => c is T);
        }

        public static string GetName(this Enum enumValue)
        {
            var attr = GetAttribute<DisplayNameAttribute>(enumValue);

            return attr == null ? enumValue.ToString() : attr.DisplayName;
        }
    }
}
