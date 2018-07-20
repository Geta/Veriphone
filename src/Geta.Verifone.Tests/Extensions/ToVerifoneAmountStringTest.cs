using FluentAssertions;
using Geta.Verifone.Extensions;
using Xunit;

namespace Geta.Verifone.Tests.Extensions
{
    public class ToVerifoneAmountStringTest
    {
        [Fact]
        public void WholeNumber()
        {
            var value = 65m;
            var expected = "6500";

            var actual = value.ToVerifoneAmountString();

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void SingleDecimalPlace()
        {
            var value = 65.0m;
            var expected = "6500";

            var actual = value.ToVerifoneAmountString();

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void TwoDecimalPlaces()
        {
            var value = 65.00m;
            var expected = "6500";

            var actual = value.ToVerifoneAmountString();

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void MultipleDecimalPlaces()
        {
            var value = 65.000000m;
            var expected = "6500";

            var actual = value.ToVerifoneAmountString();

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Rounding()
        {
            var value = 65.009m;
            var expected = "6501";

            var actual = value.ToVerifoneAmountString();

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void RoundingMidpoint()
        {
            var value = 65.55555m;
            var expected = "6556";

            var actual = value.ToVerifoneAmountString();

            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Roundingbankers()
        {
            var value = 65.045m;
            var expected = "6504";

            var actual = value.ToVerifoneAmountString();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}