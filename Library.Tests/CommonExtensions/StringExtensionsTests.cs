namespace Library.Tests.CommonExtensions
{
    using Library.CommonExtensions;
    using Xunit;

    public class StringExtensionsTests
    {
        #region IsEmpty

        [Fact]
        public void IsEmpty_EmptyString_ReturnsTrue()
        {
            Assert.True(string.Empty.IsEmpty());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("not empty")]
        public void IsEmpty_NullWhitespaceOrValidString_Returnsfalse(string value)
        {
            Assert.False(value.IsEmpty());
        }

        #endregion

        #region IsNullOrEmpty

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsNullOrEmpty_NullOrEmptyString_ReturnsTrue(string value)
        {
            Assert.True(value.IsNullOrEmpty());
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("hello")]
        [InlineData("hello world")]
        public void IsNullOrEmpty_ValidStringOrWhitespace_ReturnsFalse(string value)
        {
            Assert.False(value.IsNullOrEmpty());
        }

        #endregion

        #region IsNullOrWhitespace

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsNullOrWhitespace_NullWhitespaceOrEmptyString_ReturnsTrue(string value)
        {
            Assert.True(value.IsNullOrWhitespace());
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("hello world")]
        public void IsNullOrWhitespace_ValidString_ReturnsFalse(string value)
        {
            Assert.False(value.IsNullOrWhitespace());
        }

        #endregion
    }
}
