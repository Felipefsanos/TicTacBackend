using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Infra.Helpers.Extension.Methods
{
    public static class StringExtensionMethods
    {
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
    }
}
