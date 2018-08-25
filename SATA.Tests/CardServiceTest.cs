using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using SATA.Constants;
using SATA.Models.Request;
using SATA.Repository;
using SATA.Services.CardService;
using SATA.Services.ExpiryService;
using Xunit;


namespace SATA.Tests
{
    public class CardServiceTest
    {
        [Fact]
        public void GetCardType_VisaCard()
        {
            var options = new DbContextOptionsBuilder<SATADbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            var dbContext = new SATADbContext(options);
            var expiryService = A.Fake<IExpiryService>();

            var cardService = new CardService(dbContext, expiryService);
            var card = new Card
            {
                CardNumber = "912341234123412",
                ExpiryDate = "102020"
            };
            var cardType = cardService.GetCardType(card);
            Assert.Equal(CardType.WrongFormatCard,cardType);
        }
    }
}
