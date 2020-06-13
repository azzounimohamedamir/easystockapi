using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Helpers
{
    public static class StringHelper
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }
        public static bool NotNullOrEmpty(this string input)
        {
            return !input.IsNullOrEmpty();
        }

        public static decimal FormatDecimal(this decimal input,short digits=2)
        {
           return decimal.Round(input, digits, MidpointRounding.AwayFromZero);
        }
        public static string FormatDecimal(this decimal input)
        {
            return input.ToString("N2");
        }
        /// <summary>
        /// null-> Guid.Empty
        /// string -> Guid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string input)
        {
            if (input.IsNullOrEmpty()) return Guid.Empty;
            Guid.TryParse(input, out Guid output);
            return output;
        }

        public static Guid? ToNullableGuid(this string input)
        {
            if (input.IsNullOrEmpty()) return null;
            Guid.TryParse(input, out Guid output);
            return output;
        }

        public static string ToSlugUrl(this string input)
        {
            if (input != null && !string.IsNullOrEmpty(input))
            {
                //First to lower case
                input = input.ToLowerInvariant();

                //Remove all accents
                var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(input);
                input = Encoding.ASCII.GetString(bytes);

                //Replace spaces 
                input = Regex.Replace(input, @"\s", "-", RegexOptions.Compiled);

                //Remove invalid chars 
                input = Regex.Replace(input, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

                //Trim dashes from end 
                input = input.Trim('-', '_');

                //Replace double occurences of - or \_ 
                input = Regex.Replace(input, @"([-_]){2,}", "$1", RegexOptions.Compiled);

                return input;
            }
            else
            {
                return input;
            }
        }

        public static string RemoveAccent(this string input)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(input);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

    }
}
