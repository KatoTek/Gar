using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.String;
using static System.Text.RegularExpressions.Regex;

namespace Gar.Business.Extensions
{
    public static class StringExtensions
    {
        #region methods

        public static string SlimTrim(this string value, char trimChar) => value.SlimTrimStart(trimChar)
                                                                                .SlimTrimEnd(trimChar);

        public static string SlimTrim(this string value, string trimString) => value.SlimTrimStart(trimString)
                                                                                    .SlimTrimEnd(trimString);

        public static string SlimTrimEnd(this string value, char trimChar) => IsNullOrEmpty(value)
                                                                                  ? value
                                                                                  : value.EndsWith(trimChar.ToString())
                                                                                        ? value.Substring(0, value.Length - 1)
                                                                                        : value;

        public static string SlimTrimEnd(this string value, string trimString) => IsNullOrEmpty(value)
                                                                                      ? value
                                                                                      : value.EndsWith(trimString)
                                                                                            ? value.Substring(0, value.Length - trimString.Length)
                                                                                            : value;

        public static string SlimTrimStart(this string value, char trimChar) => IsNullOrEmpty(value)
                                                                                    ? value
                                                                                    : value.StartsWith(trimChar.ToString())
                                                                                          ? value.Substring(1, value.Length - 1)
                                                                                          : value;

        public static string SlimTrimStart(this string value, string trimString) => IsNullOrEmpty(value)
                                                                                        ? value
                                                                                        : value.StartsWith(trimString)
                                                                                              ? value.Substring(trimString.Length, value.Length - trimString.Length)
                                                                                              : value;

        public static string TrimWithin(this string value) => IsNullOrWhiteSpace(value)
                                                                  ? Empty
                                                                  : Replace(value, @"\s+|\t|\n|\r", " ")
                                                                        .Trim();

        public static string[] Words(this string value, IEnumerable<char> delimiters)
        {
            if (IsNullOrEmpty(value))
                return new string[0];

            if (delimiters == null)
                return new[] { value };

            var delimitersArray = delimiters as char[] ?? delimiters.ToArray();
            if (!delimitersArray.Any())
                return new[] { value };

            return
                Split(value,
                      $"[{delimitersArray.Aggregate(new StringBuilder(), (sb, delimiter) => sb.Append($"{Escape(delimiter.ToString())}")) .ToString() .Trim('|') .Replace(' ', 's')}]+")
                    .Select(s => s?.Trim())
                    .Where(s => !IsNullOrEmpty(s))
                    .ToArray();
        }

        public static string[] Words(this string value, char? qualifier, IEnumerable<char> delimiters)
        {
            if (IsNullOrEmpty(value))
                return new string[0];

            if (!qualifier.HasValue)
                return value.Words(delimiters);

            if (delimiters == null)
                return new[] { value };

            var delimitersArray = delimiters as char[] ?? delimiters.ToArray();
            if (!delimitersArray.Any())
                return new[] { value };

            var d =
                $"[{delimitersArray.Aggregate(new StringBuilder(), (sb, delimiter) => sb.Append($"{Escape(delimiter.ToString())}")) .ToString() .Trim('|') .Replace(' ', 's')}]+";
            var q = Escape(qualifier.ToString());
            return Split(value, $"{d}(?=(?:[^{q}]*{q}[^{q}]*{q})*(?![^{q}]*{q}))")
                .Select(s => s?.Trim()
                               .SlimTrim(qualifier.Value)
                               .Replace($"{qualifier.Value.ToString()}{qualifier.Value.ToString()}", qualifier.Value.ToString()))
                .Where(s => !IsNullOrEmpty(s))
                .ToArray();
        }

        #endregion
    }
}
