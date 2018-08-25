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
        #region GetCardType
        [Fact]
        public void GetCardType_VisaCard()
        {
            var options = new DbContextOptionsBuilder<SATADbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            var dbContext = new SATADbContext(options);
            var expiryService = A.Fake<IExpiryService>();

            var cardService = new CardService(dbContext, expiryService);
            var card = new Card
            {
                CardNumber = "4123412341234123",
                ExpiryDate = "102020"
            };
            var cardType = cardService.GetCardType(card);
            Assert.Equal(CardType.Visa, cardType);
        }

        [Fact]
        public void GetCardType_MasterCard()
        {
            var options = new DbContextOptionsBuilder<SATADbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            var dbContext = new SATADbContext(options);
            var expiryService = A.Fake<IExpiryService>();

            var cardService = new CardService(dbContext, expiryService);
            var card = new Card
            {
                CardNumber = "5123412341234123",
                ExpiryDate = "102020"
            };
            var cardType = cardService.GetCardType(card);
            Assert.Equal(CardType.Master, cardType);
        }

        [Fact]
        public void GetCardType_AmexCard()
        {
            var options = new DbContextOptionsBuilder<SATADbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            var dbContext = new SATADbContext(options);
            var expiryService = A.Fake<IExpiryService>();

            var cardService = new CardService(dbContext, expiryService);
            var card = new Card
            {
                CardNumber = "312341234123412",
                ExpiryDate = "102020"
            };
            var cardType = cardService.GetCardType(card);
            Assert.Equal(CardType.Amex, cardType);
        }

        [Fact]
        public void GetCardType_JCB()
        {
            var options = new DbContextOptionsBuilder<SATADbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            var dbContext = new SATADbContext(options);
            var expiryService = A.Fake<IExpiryService>();

            var cardService = new CardService(dbContext, expiryService);
            var card = new Card
            {
                CardNumber = "3123412341234123",
                ExpiryDate = "102020"
            };
            var cardType = cardService.GetCardType(card);
            Assert.Equal(CardType.JCB, cardType);
        }

        [Fact]
        public void GetCardType_WrongFormatCard()
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
        #endregion
    }
}
