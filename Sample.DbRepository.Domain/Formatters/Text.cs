﻿using System;
using System.Globalization;

namespace Sample.DbRepository.Domain.Formatters
{
    public static class Text
    {
        public static string ToPascalCase(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return text;

            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            return ti.ToTitleCase(text);
        }
    }
}
