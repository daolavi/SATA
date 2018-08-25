using SATA.Constants;
using SATA.Models.Request;
using SATA.Models.Response;

namespace SATA.Services.CardService
{
    public interface ICardService
    {
        bool IsExistingCard(Card card);

        CardType GetCardType(Card card);

        CheckCardResult Validate(Card card);
    }
}
