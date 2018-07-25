using System.Runtime.InteropServices;
using FluentAssertions;
using Geta.Commerce.Payments.Verifone.HostedPages.Models;
using Xunit;

namespace Geta.Verifone.Tests.Models
{
    public class VerifonePaymentRequestParameterLengthTest
    {
        [Fact]
        public void StringTooLong()
        {
            var request = new VerifonePaymentRequest();
            var value = "1234567890123456789012345678901234567890";
            var expected = "123456789012345678901234567890";

            request.BuyerFirstName = value;

            request.BuyerFirstName.Should().BeEquivalentTo(expected);
            request.BuyerFirstName.Length.Should().Be(VerifoneConstants.ParameterMaxLength.BuyerFirstName);
        }
        
        [Fact]
        public void StringTooLong_ByOneCharacte()
        {
            var request = new VerifonePaymentRequest();
            var value = "1234567890123456789012345678901";
            var expected = "123456789012345678901234567890";

            request.BuyerFirstName = value;

            request.BuyerFirstName.Should().BeEquivalentTo(expected);
            request.BuyerFirstName.Length.Should().Be(VerifoneConstants.ParameterMaxLength.BuyerFirstName);
        }
        
        [Fact]
        public void StringShorter()
        {
            var request = new VerifonePaymentRequest();
            var value = "123";

            request.BuyerFirstName = value;

            request.BuyerFirstName.Should().BeEquivalentTo(value);
            request.BuyerFirstName.Length.Should().Be(value.Length);
        }
        
        [Fact]
        public void StringShorter_ByOneCharacter()
        {
            var request = new VerifonePaymentRequest();
            var value = "1234567890123456789";

            request.BuyerFirstName = value;

            request.BuyerFirstName.Should().BeEquivalentTo(value);
            request.BuyerFirstName.Length.Should().Be(value.Length);
        }
        
        [Fact]
        public void StringExactlyMaxLength()
        {
            var request = new VerifonePaymentRequest();
            var value = "123456789012345678901234567890";

            request.BuyerFirstName = value;

            request.BuyerFirstName.Should().BeEquivalentTo(value);
            request.BuyerFirstName.Length.Should().Be(value.Length);
        }
    }
}