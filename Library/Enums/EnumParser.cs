using System;
using Library.Guards;

namespace Library.Enums
{
    public class EnumParser
    {
        public static T Parse<T>(string value) where T : struct, IConvertible
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(value), value);

            return Parse<T>(value, false);
        }

        public static T Parse<T>(string value, bool ignoreCase) where T : struct, IConvertible
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(value), value);

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be enum");
            }

            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
