namespace Library.Tests.CommonExtensions
{
    using System;
    using System.Collections.Generic;

    using Library.CommonExtensions;

    using Xunit;

    public class GenericExtensionsTests
    {
        [Fact]
        public void IsNulOrEmpty_NullList_ReturnsTrue()
        {
            Assert.True((null as List<string>).IsNullOrEmpty());
        }

        [Fact]
        public void IsNulOrEmpty_EmptyList_ReturnsTrue()
        {
            Assert.True(new List<string>().IsNullOrEmpty());
        }

        [Fact]
        public void IsNulOrEmpty_ValidList_ReturnsFalse()
        {
            Assert.False(new List<string> { "hello", "world" }.IsNullOrEmpty());
        }

        [Fact]
        public void TryGetValue_NullDictionary_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => (null as IDictionary<string, int>).TryGetValue("key"));
        }

        [Fact]
        public void TryGetValue_DictionaryWithValueTypeValueAndKeyDoesNotExist_ReturnsDefaultValue()
        {
            // Arrange
            var sut = new Dictionary<int, decimal>
            {
                { 1, 10.5m },
                { 2, 17.2m },
                { 3, 59.9m }
            };

            // Act
            var result = sut.TryGetValue(5);

            // Assert
            Assert.Equal(default(decimal), result);
        }

        [Fact]
        public void TryGetValue_DictionaryWithValueTypeValueAndKeyExists_ReturnsExpectedValue()
        {
            // Arrange
            var sut = new Dictionary<int, decimal>
            {
                { 1, 10.5m },
                { 2, 17.2m },
                { 3, 59.9m }
            };

            // Act
            var result = sut.TryGetValue(2);

            // Assert
            Assert.Equal(17.2m, result);
        }

        [Fact]
        public void TryGetValue_DictionaryWithReferenceTypeValueAndKeyDoesNotExist_ReturnsNull()
        {
            // Arrange
            var sut = new Dictionary<int, TestClass>
            {
                { 1, new TestClass { Id = 1, Name = "Item 1" } },
                { 2, new TestClass { Id = 2, Name = "Item 2" } },
                { 3, new TestClass { Id = 3, Name = "Item 3" } }
            };

            // Act
            var result = sut.TryGetValue(5);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void TryGetValue_DictionaryWithReferenceTypeValueAndKeyExists_ReturnsExpectedValue()
        {
            // Arrange
            var sut = new Dictionary<int, TestClass>
            {
                { 1, new TestClass { Id = 1, Name = "Item 1" } },
                { 2, new TestClass { Id = 2, Name = "Item 2" } },
                { 3, new TestClass { Id = 3, Name = "Item 3" } }
            };

            // Act
            var result = sut.TryGetValue(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Id);
            Assert.Equal("Item 2", result.Name);
        }

        [Fact]
        public void Join_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<string>).Join(", "));
        }

        [Fact]
        public void Join_ValidList_ReturnsConcatinatedString()
        {
            // Assign
            var sut = new List<string>
            {
                "one",
                "two",
                "three"
            };

            var expected = "one, two, three";

            // Action
            var result = sut.Join(", ");

            // Assert
            Assert.Equal(expected, result);
        }

        private class TestClass
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
