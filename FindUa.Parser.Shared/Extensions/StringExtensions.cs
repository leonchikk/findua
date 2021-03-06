﻿using System.Text.RegularExpressions;

namespace FindUa.Parser.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            return Regex.Replace(str, "[*'\",_&#^@]", "", RegexOptions.Compiled);
        }

        public static string RemoveAllWhiteSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", "", RegexOptions.Compiled);
        }

        public static string RemoveAllTabulations(this string str)
        {
            return Regex.Replace(str, @"[\t]", "", RegexOptions.Compiled);
        }

        public static string RemoveAllDashes(this string str)
        {
            return Regex.Replace(str, @"-", " ", RegexOptions.Compiled);
        }
    }
}
