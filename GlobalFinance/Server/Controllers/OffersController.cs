using GlobalFinance.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace GlobalFinance.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OffersController : ControllerBase
    {
        private List<OfferModel> _offers = new() {
            
                new() {OfferId=0, OfferPrice=300, OfferExpiry="2022, 12, 2", CarId=0},
                new() {OfferId=1, OfferPrice=340, OfferExpiry="2022, 12, 2", CarId=1},
                new() {OfferId = 2, OfferPrice = 350, OfferExpiry = "2022, 12, 2", CarId = 2 },
                new() {OfferId = 3, OfferPrice = 290, OfferExpiry = "2022, 12, 2", CarId = 3 },
                new() {OfferId = 4, OfferPrice = 300, OfferExpiry = "2022, 12, 2", CarId = 4 },
                new() {OfferId = 5, OfferPrice = 360, OfferExpiry = "2022, 12, 2", CarId = 5 },
                new() {OfferId = 6, OfferPrice = 390, OfferExpiry = "2022, 12, 2", CarId = 6 },
                new() {OfferId = 7, OfferPrice = 400, OfferExpiry = "2022, 12, 2", CarId = 7 },
                new() {OfferId = 8, OfferPrice = 200, OfferExpiry = "2022, 12, 2", CarId = 8 },
                new() {OfferId = 9, OfferPrice = 300, OfferExpiry = "2022, 12, 2", CarId = 9 },
            };

        [HttpGet("list")]
        public ActionResult List()
        {
            return Ok(_offers);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var offer = _offers.Find(c => c.OfferId == id);
            if (offer is not null)
            {
                return Ok(offer);
            }
            return NotFound();
        }
    }
}
