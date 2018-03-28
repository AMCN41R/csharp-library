using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.CommonTestHelpers
{
    public static class Custom
    {
        public static class Assert
        {
            public static void HasAttribute<T>(Type objectType) where T : Attribute
            {
                var attr = objectType.GetCustomAttributes(typeof(T), false).ToList();
                attr.AssertAttributeCount<T>();
            }

            public static void HasAttribute<T>(Enum @enum) where T : Attribute
            {
                var type = @enum.GetType();
                var memberInfo = type.GetMember(Enum.GetName(type, @enum));
                var attr = memberInfo[0].GetCustomAttributes(typeof(T), false).ToList();

                attr.AssertAttributeCount<T>();
            }

            public static void MethodHasAttribute<T>(Type objectType, string methodName)
                where T : Attribute
            {
                var method = objectType.GetMethod(methodName);

                if (method == null)
                {
                    throw new Exception($"Method {methodName} does not exist on type {objectType}.");
                }

                var attr = method.GetCustomAttributes(typeof(T), false).ToList();
                attr.AssertAttributeCount<T>();
            }

            public static void PropertyHasAttribute<T>(Type objectType, string propertyName)
                where T : Attribute
            {
                var method = objectType.GetProperty(propertyName);

                if (method == null)
                {
                    throw new Exception($"Property {propertyName} does not exist on type {objectType}.");
                }

                var attr = method.GetCustomAttributes(typeof(T), false).ToList();
                attr.AssertAttributeCount<T>();
            }

            /// <summary>
            /// This is an empty function that simply serves to make tests more readable
            /// when checking that a certain action did not result in an exception.
            /// </summary>
            public static void DidNotThrow()
            {
                // ReSharper disable once RedundantJumpStatement
                return;
            }

            public static void ControllerHasRouteAttribute<TController>(string route)
            where TController : ControllerBase
            {
                var attr = typeof(TController).GetCustomAttributes(typeof(RouteAttribute), false).ToList();

                attr.AssertAttributeCount<RouteAttribute>();

                Xunit.Assert.Equal(route.ToLower(), ((RouteAttribute)attr[0]).Template.ToLower());
            }

            public static void ControllerMethodHasVerb<TController, TVerbAttribute>(string methodName)
                where TController : ControllerBase
                where TVerbAttribute : HttpMethodAttribute
            {
                var method = typeof(TController).GetMethod(methodName);

                var attr = method?.GetCustomAttributes(typeof(TVerbAttribute), false).ToList();

                attr.AssertAttributeCount<TVerbAttribute>();
            }

            public static void ControllerMethodHasVerb<TController, TVerbAttribute>(string methodName, string template)
                where TController : ControllerBase
                where TVerbAttribute : HttpMethodAttribute
            {
                var method = typeof(TController).GetMethod(methodName);

                var attr = method?.GetCustomAttributes(typeof(TVerbAttribute), false).ToList();

                if (attr == null)
                {
                    throw new Exception("No custom attributes found.");
                }

                attr.AssertAttributeCount<TVerbAttribute>();

                var verb = (HttpMethodAttribute)attr[0];

                Xunit.Assert.Equal(template, verb.Template);
            }

            public static void ControllerMethodHasRoute<TController>(string methodName, string template)
                where TController : ControllerBase
            {
                var method = typeof(TController).GetMethod(methodName);

                var attr = method?.GetCustomAttributes(typeof(RouteAttribute), false).ToList();

                if (attr == null)
                {
                    throw new Exception("No custom attributes found.");
                }

                attr.AssertAttributeCount<RouteAttribute>();

                Xunit.Assert.Equal(template.ToLower(), ((RouteAttribute)attr[0]).Template.ToLower());
            }
        }

        private static void AssertAttributeCount<T>(this ICollection<object> attr)
            where T : Attribute
        {
            var baseMessage = $"Assert has {typeof(T).Name} attribute failure.";

            if (attr.Count == 0)
            {
                throw new Exception($"{baseMessage} No such attribute.");
            }

            if (attr.Count > 1)
            {
                throw new Exception(
                    $"{baseMessage} Attribute exists {attr.Count} times.");
            }
        }
    }
}
