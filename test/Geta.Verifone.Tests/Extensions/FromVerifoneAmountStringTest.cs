using System;
using FluentAssertions;
using Geta.Verifone.Extensions;
using Xunit;

namespace Geta.Verifone.Tests.Extensions
{
    public class FromVerifoneAmountStringTest
    {
        [Fact]
        public void NoDecimalPlaces()
        {
            var value = "64500";
            var expected = 645m;

            var actual = value.FromVerifoneAmountString();

            actual.Should().Be(expected);
        }
        
        [Fact]
        public void TwoDecimalPlaces()
        {
            var value = "645";
            var expected = 6.45m;

            var actual = value.FromVerifoneAmountString();

            actual.Should().Be(expected);
        }
        
        [Fact]
        public void OneDecimalPlace()
        {
            var value = "6450";
            var expected = 64.5m;

            var actual = value.FromVerifoneAmountString();

            actual.Should().Be(expected);
        }
        
        [Fact]
        public void LessThanOne_OneDecimalPlace()
        {
            var value = "50";
            var expected = 0.5m;

            var actual = value.FromVerifoneAmountString();

            actual.Should().Be(expected);
        }
        
        [Fact]
        public void LessThanOne_TwoDecimalPlaces()
        {
            var value = "54";
            var expected = 0.54m;

            var actual = value.FromVerifoneAmountString();

            actual.Should().Be(expected);
        }
        
        [Fact]
        public void SingleDigitString()
        {
            var value = "5";
            var expected = 0.05m;

            var actual = value.FromVerifoneAmountString();

            actual.Should().Be(expected);
        }
        
        [Fact]
        public void OnlyIntegerValues()
        {
            Action convert = () => "5.5".FromVerifoneAmountString();

            convert.Should().Throw<FormatException>();
        }
        
        [Fact]
        public void EmptyString()
        {
            Action convert = () => string.Empty.FromVerifoneAmountString();

            convert.Should().Throw<FormatException>();
        }
    }
}