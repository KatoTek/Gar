using System.Linq;
using static System.String;
using static System.Text.RegularExpressions.Regex;

namespace Gar.Business.Extensions
{
    public static class StringExtensions
    {
        #region methods

        public static string TrimWithin(this string value) => IsNullOrWhiteSpace(value) ? Empty : Replace(value, @"\s+|\t|\n|\r", " ");

        public static string[] WordArray(this string value, char delimiter)
            => IsNullOrWhiteSpace(value) ? new string[0] : value.Split(delimiter).Where(s => !IsNullOrWhiteSpace(s)).ToArray();

        public static string[] WordArray(this string value, char delimiter, char qualifier)
        {
            var d = Escape(delimiter.ToString());
            var q = Escape(qualifier.ToString());
            return IsNullOrWhiteSpace(value)
                       ? new string[0]
                       : Split(value, $"{d}(?=(?:[^{q}]*{q}[^{q}]*{q})*(?![^{q}]*{q}))").Select(s => s.Trim().Trim(qualifier)).Where(s => !IsNullOrWhiteSpace(s)).ToArray();
        }

        #endregion
    }
}
