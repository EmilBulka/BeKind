using System.Text.RegularExpressions;

namespace BeKind.Infrastructure.Helpers
{
    public static class StringExtenstions
    {
        public static string InsertSpacesBetweenEach(this String value)
        {
            return Regex.Replace(value, "(?<!^)([A-Z])", " $1").Trim();
        }
    }
}
