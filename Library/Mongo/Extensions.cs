using System;
using Library.Guards;

namespace Library.Mongo
{
    public static class Extensions
    {
        /// <summary>
        /// Sets the entity's id to <see cref="Guid.NewGuid"/> if it is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity to update.</param>
        public static void SetId<T>(this T entity) where T : class, IEntity
        {
            Guard.AgainstNullArgument(nameof(entity), entity);

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
        }

        /// <summary>
        /// Converts a base64 encode guid back to its original form.
        /// </summary>
        /// <param name="base64String">The string to convert.</param>
        /// <returns><see cref="Guid"/></returns>
        public static Guid GuidFromBase64String(string base64String)
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(base64String), base64String);

            return new Guid(Convert.FromBase64String(base64String));
        }

        /// <summary>
        /// Turns a guid into a base64 encoded string.
        /// </summary>
        /// <param name="guid">THe guid to convert.</param>
        /// <returns>The guid as a base64 encoded string.</returns>
        public static string ToBase64String(this Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray());
        }
    }
    
}
