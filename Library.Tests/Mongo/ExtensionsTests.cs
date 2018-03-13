using System;
using Library.Mongo;
using Xunit;

namespace Library.Tests.Mongo
{
    public class ExtensionsTests
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

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GuidFromBase64String_NullEmptyOrWhitespaceString_ThrowsException(string value)
        {
            Assert.ThrowsAny<Exception>(() => Extensions.GuidFromBase64String(value));
        }

        [Fact]
        public void GuidFromBase64String_ValidString_ReturnsExpectedGuid()
        {
            // Arrange
            var str = "dezGlxCQlEOn/VFnT/jVPg==";
            var expected = Guid.Parse("97c6ec75-9010-4394-a7fd-51674ff8d53e");

            // Act
            var result = Extensions.GuidFromBase64String(str);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToBase64String_ValidGuid_ReturnsExpectedString()
        {
            // Arrange
            var guid = Guid.Parse("97c6ec75-9010-4394-a7fd-51674ff8d53e");
            var expected = "dezGlxCQlEOn/VFnT/jVPg==";

            // Act
            var result = guid.ToBase64String();

            // Assert
            Assert.Equal(expected, result);
        }

        #region Helpers

        private class TestEntity : IEntity
        {
            public Guid Id { get; set; }
        }

        #endregion
    }
}
