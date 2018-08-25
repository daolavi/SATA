using Microsoft.AspNetCore.Mvc;
using SATA.Models.Request;
using SATA.Models.Response;
using SATA.Repository;
using SATA.Services.CardService;

namespace SATA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService cardService;

        public CardController(SATADbContext dbContext,ICardService cardService)
        {
            this.cardService = cardService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Card card)
        {
            var result = cardService.IsExistingCard(card) ? cardService.Validate(card) : new CheckCardResult { Result = Constants.ResultType.NOT_EXIST };
            return new JsonResult(result);
        }
    }
}
