using SATA.Constants;
using Microsoft.EntityFrameworkCore;
using SATA.Models.Request;
using SATA.Models.Response;
using SATA.Repository;
using SATA.Services.ExpiryService;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SATA.Services.CardService
{
    public class CardService : ICardService
    {
        private readonly SATADbContext dbContext;

        private readonly IExpiryService expiryService;

        public CardService(SATADbContext dbContext, IExpiryService expiryService)
        {
            this.dbContext = dbContext;
            this.expiryService = expiryService;
        }

        public bool IsExistingCard(Card card)
        {
            var isExistingParameter = new SqlParameter
            {
                ParameterName = StoreProcedureConstants.IS_EXISTING_CARD_SP_IS_EXISTING_PARAM,
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
            {
                new SqlParameter(StoreProcedureConstants.IS_EXISTING_CARD_SP_CARD_NUMBER_PARAM, card.CardNumber),
                isExistingParameter
            };

            var sqlQuery = $"Exec {StoreProcedureConstants.IS_EXISTING_CARD_SP} @{StoreProcedureConstants.IS_EXISTING_CARD_SP_CARD_NUMBER_PARAM}, @{StoreProcedureConstants.IS_EXISTING_CARD_SP_IS_EXISTING_PARAM} OUTPUT";
            dbContext.Database.ExecuteSqlCommand(sqlQuery, parameters);

            var result = isExistingParameter.Value as bool? ?? default(bool);

            return result;
        }

        public CardType GetCardType(Card card)
        {
            var cardNumber = card.CardNumber;
            if (CardConstants.WELL_KNOWN_START_NUMBER.Any(x => cardNumber.StartsWith(x)))
            {
                if (cardNumber.StartsWith(CardConstants.VISA_START_NUMBER) && cardNumber.Length == CardConstants.VISA_LENGTH)
                    return CardType.Visa;
                else if (cardNumber.StartsWith(CardConstants.MASTERCARD_START_NUMBER) && cardNumber.Length == CardConstants.MASTERCARD_LENGTH)
                    return CardType.Master;
                else if (cardNumber.StartsWith(CardConstants.AMEX_START_NUMBER) && cardNumber.Length == CardConstants.AMEX_LENGTH)
                    return CardType.Amex;
                else if (cardNumber.StartsWith(CardConstants.JCB_START_NUMBER) && cardNumber.Length == CardConstants.JCB_LENGTH)
                    return CardType.JCB;
            }
            else if (cardNumber.Length == CardConstants.UNKNOWNCARD_LENGTH)
                return CardType.Unknown;

            return CardType.WrongFormatCard;
        }

        public CheckCardResult Validate(Card card)
        {
            var cardType = GetCardType(card);
            if (cardType == CardType.WrongFormatCard)
            {
                return new CheckCardResult{ Result = ResultType.INVALID};
            }
            else if (cardType == CardType.Visa && !expiryService.IsLeapYear(card.ExpiryDate))
            {
                return new CheckCardResult { Result = ResultType.INVALID };
            }
            else if (cardType == CardType.Master && !expiryService.IsPrimeNumber(card.ExpiryDate))
            {
                return new CheckCardResult { Result = ResultType.INVALID };
            }

            return new CheckCardResult { Result = ResultType.VALID, CardType = cardType.ToString() };
        }
    }
}
