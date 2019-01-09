using Chapter01;
using FluentAssertions;
using Xunit;

namespace Ch_01._Arrays_and_Strings_Tests
{
    public class IsUniqueTests
    {
        [Theory]
        [InlineData("abcde")]
        [InlineData("kite")]
        [InlineData("padle")]
        public void IsUnique_should_be_true(string word)
        {
            var unique = new Q1_01_Is_Unique();
            unique.IsUniqueChars(word).Should().BeTrue();
            unique.IsUniqueChars2(word).Should().BeTrue();
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("apple")]
        public void IsUnique_should_be_false(string word)
        {
            var unique = new Q1_01_Is_Unique();
            unique.IsUniqueChars(word).Should().BeFalse();
            unique.IsUniqueChars2(word).Should().BeFalse();
        }
    }
}
