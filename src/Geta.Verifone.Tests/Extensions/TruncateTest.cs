using FluentAssertions;
using Geta.Verifone.Extensions;
using Xunit;

namespace Geta.Verifone.Tests.Extensions
{
    public class TruncateTest
    {
        [Fact]
        public void StringLongerThanLength()
        {
            var value = "12345678";
            var length = 3;
            var expected = "123";

            var actual = value.Truncate(length);

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void StringShorterThanLength()
        {
            var value = "123";
            var length = 99;
            var expected = "123";

            var actual = value.Truncate(length);

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void StringSameAsLength()
        {
            var value = "123";
            var length = 3;
            var expected = "123";

            var actual = value.Truncate(length);

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void StringReferenceDoesNotChange()
        {
            var value = "123456";
            var length = 3;
            var expected = "123456";

            var actual = value.Truncate(length);

            value.Should().BeEquivalentTo(expected);
        }
    }
}