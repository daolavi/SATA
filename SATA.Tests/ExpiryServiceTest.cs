using SATA.Services.ExpiryService;
using Xunit;

namespace SATA.Tests
{
    public class ExpiryServiceTest
    {
        [Fact]
        public void LeapYear_True()
        {
            var expiryService = new ExpiryService();
            var result = expiryService.IsLeapYear("102020");
            Assert.True(result);
        }

        [Fact]
        public void LeapYear_False()
        {
            var expiryService = new ExpiryService();
            var result = expiryService.IsLeapYear("102100");
            Assert.False(result);
        }

        [Fact]
        public void PrimeNumber_True()
        {
            var expiryService = new ExpiryService();
            var result = expiryService.IsPrimeNumber("102027");
            Assert.True(result);
        }

        [Fact]
        public void PrimeNumber_False()
        {
            var expiryService = new ExpiryService();
            var result = expiryService.IsPrimeNumber("102020");
            Assert.False(result);
        }
    }
}
