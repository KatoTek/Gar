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

        public static string TrimWithin(this string value) => IsNullOrWhiteSpace(value) ? Empty : Replace(value, @"\s+|\t|\n|\r", " ").Trim();

        public static string[] Words(this string value, IEnumerable<char> delimiters)
            =>
                IsNullOrWhiteSpace(value)
                    ? new string[0]
                    : Split(value,
                            $"[{delimiters.Aggregate(new StringBuilder(), (sb, delimiter) => sb.Append($"{Escape(delimiter.ToString())}")).ToString().Trim('|').Replace(' ', 's')}]+")
                          .Select(s => s.Trim())
                          .Where(s => !IsNullOrWhiteSpace(s))
                          .ToArray();

        public static string[] Words(this string value, char qualifier, IEnumerable<char> delimiters)
        {
            var d = $"[{delimiters.Aggregate(new StringBuilder(), (sb, delimiter) => sb.Append($"{Escape(delimiter.ToString())}")).ToString().Trim('|').Replace(' ', 's')}]+";
            var q = Escape(qualifier.ToString());
            return IsNullOrWhiteSpace(value)
                       ? new string[0]
                       : Split(value, $"{d}(?=(?:[^{q}]*{q}[^{q}]*{q})*(?![^{q}]*{q}))").Select(s => s.Trim().Trim(qualifier)).Where(s => !IsNullOrWhiteSpace(s)).ToArray();
        }

        #endregion
    }
}
