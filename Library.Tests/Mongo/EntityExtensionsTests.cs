namespace Library.Tests.Mongo
{
    using System;

    using Library.Mongo;

    using Xunit;

    public class EntityExtensionsTests
    {
        [Fact]
        public void SetId_EntityWithEmptyGuidId_IsReturnedWithValidGuidId()
        {
            // Arrange
            var entity = new TestEntity { Id = Guid.Empty };

            // Act
            entity.SetId();

            // Assert
            Assert.NotEqual(Guid.Empty, entity.Id);
        }

        [Fact]
        public void SetId_EntityWithValidGuidId_IsReturnedUnchanged()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new TestEntity { Id = id };

            // Act
            entity.SetId();

            // Assert
            Assert.Equal(id, entity.Id);
        }

        [Fact]
        public void SetId_NullEntity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as TestEntity).SetId());
        }

        #region Helpers

        private class TestEntity : IEntity
        {
            public Guid Id { get; set; }
        }

        #endregion
    }
}
