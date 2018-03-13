namespace Library.CommonExtensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return value == string.Empty;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhitespace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
