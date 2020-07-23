namespace Library.Mongo
{
    using System;

    using Library.Guards;

    /// <summary>
    /// A set of extension methods on <see cref="IEntity"/>.
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Sets the entity's id to <see cref="Guid.NewGuid"/> if it is empty.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to update.</param>
        public static void SetId<T>(this T entity)
            where T : class, IEntity
        {
            Guard.AgainstNullArgument(nameof(entity), entity);

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
        }
    }
}
