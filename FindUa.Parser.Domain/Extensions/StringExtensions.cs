using System.Text.RegularExpressions;

namespace FindUa.Parser.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            return Regex.Replace(str, "[*'\",_&#^@]", "", RegexOptions.Compiled);
        }

        public static string RemoveAllTabulations(this string str)
        {
            return Regex.Replace(str, @"[\t]", "", RegexOptions.Compiled);
        }
    }
}
