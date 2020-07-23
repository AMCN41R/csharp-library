namespace Library.CommonTestHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;

#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1201 // Elements must appear in the correct order

    /// <summary>
    /// A class containing custom assert methods.
    /// </summary>
    public static class Custom
    {
        /// <summary>
        /// The assert methods.
        /// </summary>
        public static class Assert
        {
            /// <summary>
            /// Verifies that an attribute is present (only once) on a given type.
            /// </summary>
            /// <typeparam name="TAtribute">The attribute type.</typeparam>
            /// <param name="objectType">The type to check.</param>
            /// <remarks>
            /// Throws an exception in the attribute is not present, or is
            /// present more than once.
            /// </remarks>
            public static void HasAttribute<TAtribute>(Type objectType)
                where TAtribute : Attribute
            {
                var attr = objectType.GetCustomAttributes(typeof(TAtribute), false).ToList();
                attr.AssertAttributeCount<TAtribute>();
            }

            /// <summary>
            /// Verifies that an attribute is present (only once) on a given enum.
            /// </summary>
            /// <typeparam name="TAttribute">The attribute type.</typeparam>
            /// <param name="enum">The enum to check.</param>
            /// <remarks>
            /// Throws an exception in the attribute is not present, or is
            /// present more than once.
            /// </remarks>
            public static void HasAttribute<TAttribute>(Enum @enum)
                where TAttribute : Attribute
            {
                var type = @enum.GetType();
                var memberInfo = type.GetMember(Enum.GetName(type, @enum));
                var attr = memberInfo[0].GetCustomAttributes(typeof(TAttribute), false).ToList();

                attr.AssertAttributeCount<TAttribute>();
            }

            /// <summary>
            /// Verifies that an attribute is present (only once) on a method
            /// of a given class.
            /// </summary>
            /// <typeparam name="TAttribute">The attribute type.</typeparam>
            /// <param name="objectType">The class type.</param>
            /// <param name="methodName">The name of the method.</param>
            /// <remarks>
            /// Throws an exception in the attribute is not present, or is
            /// present more than once.
            /// </remarks>
            public static void MethodHasAttribute<TAttribute>(Type objectType, string methodName)
                where TAttribute : Attribute
            {
                var method = objectType.GetMethod(methodName);

                if (method == null)
                {
                    throw new Exception($"Method {methodName} does not exist on type {objectType}.");
                }

                var attr = method.GetCustomAttributes(typeof(TAttribute), false).ToList();
                attr.AssertAttributeCount<TAttribute>();
            }

            /// <summary>
            /// Verifies that an attribute is present (only once) on a property
            /// of a given class.
            /// </summary>
            /// <typeparam name="TAttribute">The attribute type.</typeparam>
            /// <param name="objectType">The class type.</param>
            /// <param name="propertyName">The property name.</param>
            /// <remarks>
            /// Throws an exception in the attribute is not present, or is
            /// present more than once.
            /// </remarks>
            public static void PropertyHasAttribute<TAttribute>(Type objectType, string propertyName)
                where TAttribute : Attribute
            {
                var method = objectType.GetProperty(propertyName);

                if (method == null)
                {
                    throw new Exception($"Property {propertyName} does not exist on type {objectType}.");
                }

                var attr = method.GetCustomAttributes(typeof(TAttribute), false).ToList();
                attr.AssertAttributeCount<TAttribute>();
            }

            /// <summary>
            /// This is an empty function that simply serves to make tests more readable
            /// when checking that a certain action did not result in an exception.
            /// </summary>
            /// <example>
            /// <code lang="C#">
            /// public class MyMongoIntegrationTests : HarnessBase
            /// {
            ///     [Fact]
            ///     public void Test()
            ///     {
            ///         // Test something...
            ///
            ///         Custom.Assert.DidNotThrow()
            ///     }
            /// }
            /// </code>
            /// </example>
            public static void DidNotThrow()
            {
                return;
            }

            /// <summary>
            /// Verifies that a controller has the <see cref="RouteAttribute"/>
            /// with the specified route.
            /// </summary>
            /// <typeparam name="TController">The controller type.</typeparam>
            /// <param name="route">The route.</param>
            /// <remarks>
            /// Throws an exception is the <see cref="RouteAttribute"/> is missing
            /// or appears more than once, or if the route does not match.
            /// </remarks>
            public static void ControllerHasRouteAttribute<TController>(string route)
                where TController : ControllerBase
            {
                var attr = typeof(TController).GetCustomAttributes(typeof(RouteAttribute), false).ToList();

                attr.AssertAttributeCount<RouteAttribute>();

                Xunit.Assert.Equal(route.ToLower(), ((RouteAttribute)attr[0]).Template.ToLower());
            }

            /// <summary>
            /// Verifies that a controller has the correct <see cref="HttpMethodAttribute"/>.
            /// </summary>
            /// <typeparam name="TController">The controller type.</typeparam>
            /// <typeparam name="TVerbAttribute">The verb type.</typeparam>
            /// <param name="methodName">The method name.</param>
            /// <remarks>
            /// Throws an exception is the <typeparamref name="TVerbAttribute"/>
            /// is missing or appears more than once.
            /// </remarks>
            public static void ControllerMethodHasVerb<TController, TVerbAttribute>(string methodName)
                where TController : ControllerBase
                where TVerbAttribute : HttpMethodAttribute
            {
                var method = typeof(TController).GetMethod(methodName);

                var attr = method?.GetCustomAttributes(typeof(TVerbAttribute), false).ToList();

                attr.AssertAttributeCount<TVerbAttribute>();
            }

            /// <summary>
            /// Verifies that a controller has the correct <see cref="HttpMethodAttribute"/>
            /// with the specified template.
            /// </summary>
            /// <typeparam name="TController">The controller type.</typeparam>
            /// <typeparam name="TVerbAttribute">The verb type.</typeparam>
            /// <param name="methodName">The method name.</param>
            /// <param name="template">The template.</param>
            /// <remarks>
            /// Throws an exception is the <typeparamref name="TVerbAttribute"/>
            /// is missing or appears more than once, or if the template does
            /// not match.
            /// </remarks>
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

            /// <summary>
            /// Verifies that a method has the <see cref="RouteAttribute"/>
            /// with the specified template.
            /// </summary>
            /// <typeparam name="TController">The controller type.</typeparam>
            /// <param name="methodName">The method name.</param>
            /// <param name="template">The template.</param>
            /// <remarks>
            /// Throws an exception is the <see cref="RouteAttribute"/> is missing
            /// or appears more than once, or if the template does not match.
            /// </remarks>
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

#pragma warning restore SA1201 // Elements must appear in the correct order
#pragma warning restore SA1649 // File name must match first type name
}