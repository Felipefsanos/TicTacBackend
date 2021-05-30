using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacBackend.Infra.Helpers.Extension.Methods
{
    public static class StringExtensionMethods
    {
        public static string FirstName(this string str)
        {
            return str.Split(' ')[0];
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string IsInterned(this string str)
        {
            return string.IsInterned(str);
        }

        public static bool IsBase64(this string str)
        {
            str = str.Trim();
            return (str.Length % 4 == 0) && Regex.IsMatch(str, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}
