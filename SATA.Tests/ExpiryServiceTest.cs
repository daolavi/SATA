using SATA.Services.ExpiryService;
using System;
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
    }
}
