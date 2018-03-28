using Microsoft.AspNetCore.Mvc;

namespace Library.CommonTestHelpers
{
    public static class ActionResultConverter
    {
        public static T Convert<T>(this IActionResult response)
        {
            return (T)((ObjectResult)response).Value;
        }
    }
}