using Microsoft.AspNetCore.Mvc;

namespace Library.Tests.CommonHelpers
{
    public static class ActionResultConverter
    {
        public static T Convert<T>(this IActionResult response)
        {
            return (T)((ObjectResult)response).Value;
        }
    }
}