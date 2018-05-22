using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Library.Guards;

using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Mongo
{
    public static class CollectionExtensions
    {
        public static IFindFluent<T, T> Where<T>(this IMongoCollection<T> collection, Expression<Func<T, bool>> predicate)
        {
            Guard.AgainstNullArgument(nameof(collection), collection);
            Guard.AgainstNullArgument(nameof(predicate), predicate);

            return collection.Find(Builders<T>.Filter.Where(predicate));
        }

        public static IFindFluent<T, T> FindAll<T>(this IMongoCollection<T> collection)
        {
            Guard.AgainstNullArgument(nameof(collection), collection);

            return collection.Find(new BsonDocument());
        }

        public static Task<T> FindFirstOrDefaultAsync<T>(this IMongoCollection<T> collection)
        {
            Guard.AgainstNullArgument(nameof(collection), collection);

            return collection
                    .FindAll()
                    .Limit(1)
                    .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets a single entity from a Mongo collection.
        /// An exception will be thrown if the <paramref name="id"/> is an empty guid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The <see cref="IMongoCollection{T}"/> to search.</param>
        /// <param name="id">The unique id of the required entity.</param>
        /// <returns>A Task whose result is the single result or null.</returns>
        /// <exception cref="Guard.DefaultValueException">Thrown when the given <paramref name="id"/> is equal to <see cref="Guid.Empty"/>.</exception>
        public static async Task<T> GetOneAsync<T>(this IMongoCollection<T> collection, Guid id) where T : IEntity
        {
            Guard.AgainstNullArgument(nameof(collection), collection);
            Guard.AgainstDefaultValue(nameof(id), id);

            var filter = Builders<T>.Filter.Eq(x => x.Id, id);

            return await collection.Find(filter).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Creates a filter using the entity's id and calls <see cref="IMongoCollection{T}.ReplaceOneAsync"/>
        /// as an upsert.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="entity">The entity to insert or update.</param>
        /// <returns>The entity's id.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given <paramref name="entity"/> is null.</exception>
        public static async Task<Guid> AddOrUpdate<T>(this IMongoCollection<T> collection, T entity) where T : class, IEntity
        {
            Guard.AgainstNullArgument(nameof(collection), collection);
            Guard.AgainstNullArgument(nameof(entity), entity);

            entity.SetId();

            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            var options = new UpdateOptions { IsUpsert = true };

            await collection.ReplaceOneAsync(filter, entity, options);

            return entity.Id;
        }

        /// <summary>
        /// Creates a <see cref="ReplaceOneModel{T}"/> for each entity and calls
        /// <see cref="IMongoCollection{T}.BulkWriteAsync"/> as an upsert.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IEntity"/>.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="entities">The entities to insert or update.</param>
        /// <returns>The entities ids.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given <paramref name="entities"/> is null.</exception>
        public static async Task<IEnumerable<Guid>> AddOrUpdateMany<T>(this IMongoCollection<T> collection, ICollection<T> entities) where T : class, IEntity
        {
            Guard.AgainstNullArgument(nameof(collection), collection);
            Guard.AgainstNullArgument(nameof(entities), entities);

            if (!entities.Any())
            {
                return new List<Guid>();
            }

            var operations = new List<ReplaceOneModel<T>>();

            foreach (var entity in entities)
            {
                entity.SetId();

                var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
                var operation = new ReplaceOneModel<T>(filter, entity) { IsUpsert = true };

                operations.Add(operation);
            }

            await collection.BulkWriteAsync(operations);

            return entities.Select(e => e.Id);
        }

        /// <summary>
        /// Deletes a single entity from a Mongo collection.
        /// An exception will be thrown if the <paramref name="id"/> is an empty guid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The mongo collection to search.</param>
        /// <param name="id">The unique id of the entity to be deleted.</param>
        /// <exception cref="Guard.DefaultValueException">Thrown when the given <paramref name="id"/> is equal to <see cref="Guid.Empty"/>.</exception>
        public static async Task DeleteOneByIdAsync<T>(this IMongoCollection<T> collection, Guid id) where T : IEntity
        {
            Guard.AgainstNullArgument(nameof(collection), collection);
            Guard.AgainstDefaultValue(nameof(id), id);

            var filter = Builders<T>.Filter.Eq(x => x.Id, id);

            await collection.DeleteOneAsync(filter);
        }

        public static async Task CreateAscendingIndexes<T>(this IMongoCollection<T> collection, params Expression<Func<T, object>>[] fieldSelectors)
        {
            Guard.AgainstNullArgument(nameof(collection), collection);
            Guard.AgainstNullArgument(nameof(fieldSelectors), fieldSelectors);

            if (fieldSelectors.Length == 0)
            {
                return;
            }

            var indexes =
                fieldSelectors
                    .Select(
                        field =>
                            new CreateIndexModel<T>(
                                new IndexKeysDefinitionBuilder<T>().Ascending(field))
                    )
                    .ToList();

            await
                collection
                    .Indexes
                    .CreateManyAsync(indexes);
        }
    }
}
