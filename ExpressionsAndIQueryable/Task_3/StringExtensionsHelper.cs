﻿using System.Collections.Generic;

namespace Sample03
{
    public static class StringExtensionsHelper
    {
        public static List<string> SupportedOperations { get; }

        static StringExtensionsHelper()
        {
            SupportedOperations = new List<string> { "Contains", "StartsWith", "EndsWith" };
        }

        public static string Contains(this string source, string condition)
        {
            return $"*{condition}*";
        }

        public static string StartsWith(this string source, string condition)
        {
            return $"{condition}*";
        }

        public static string EndsWith(this string source, string condition)
        {
            return $"*{condition}";
        }
    }
}

