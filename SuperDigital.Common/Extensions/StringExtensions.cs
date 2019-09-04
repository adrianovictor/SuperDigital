using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNotEmpty(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
