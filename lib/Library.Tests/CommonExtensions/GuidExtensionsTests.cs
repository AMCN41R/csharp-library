namespace Library.Tests.Mongo
{
    using System;

    using Library.CommonExtensions;

    using Xunit;

    public class GuidExtensionsTests
    {
        #region ToGuid

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ToGuid_NullEmptyOrWhitespaceString_ThrowsException(string value)
        {
            Assert.ThrowsAny<Exception>(() => GuidExtensions.ToGuid(value));
        }

        [Fact]
        public void ToGuid_ValidString_ReturnsExpectedGuid()
        {
            // Arrange
            var str = "97c6ec75-9010-4394-a7fd-51674ff8d53e";
            var expected = Guid.Parse("97c6ec75-9010-4394-a7fd-51674ff8d53e");

            // Act
            var result = GuidExtensions.ToGuid(str);

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region ToGuidFromBase64String

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ToGuidFromBase64String_NullEmptyOrWhitespaceString_ThrowsException(string value)
        {
            Assert.ThrowsAny<Exception>(() => GuidExtensions.ToGuidFromBase64String(value));
        }

        [Fact]
        public void ToGuidFromBase64String_ValidString_ReturnsExpectedGuid()
        {
            // Arrange
            var str = "dezGlxCQlEOn/VFnT/jVPg==";
            var expected = Guid.Parse("97c6ec75-9010-4394-a7fd-51674ff8d53e");

            // Act
            var result = GuidExtensions.ToGuidFromBase64String(str);

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region ToBase64String

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

        #endregion
    }
}
