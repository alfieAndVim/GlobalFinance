using GlobalFinance.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalFinance.Server.Controllers
{
    public class OffersController : ControllerBase
    {
        private List<OfferModel> _offers = new() {
            
                new() {OfferId=0, OfferTitle="£300pm", OfferExpiry=DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId=0},
                new() {OfferId=1, OfferTitle="£340pm", OfferExpiry=DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId=1},
                new() { OfferId = 2, OfferTitle = "£350pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 2 },
                new() { OfferId = 3, OfferTitle = "£290pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 3 },
                new() { OfferId = 4, OfferTitle = "£300pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 4 },
                new() { OfferId = 5, OfferTitle = "£360pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 5 },
                new() { OfferId = 6, OfferTitle = "£390pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 6 },
                new() { OfferId = 7, OfferTitle = "£400pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 7 },
                new() { OfferId = 8, OfferTitle = "£200pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 8 },
                new() { OfferId = 9, OfferTitle = "£300pm", OfferExpiry = DateOnly.FromDateTime(new DateTime(2022, 12, 2)), CarId = 9 },
            };

        [HttpGet("list")]
        public ActionResult List()
        {
            return Ok(_offers);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var car = _offers.Find(c => c.OfferId == id);
            if (car is not null)
            {
                return Ok(car);
            }
            return NotFound();
        }
    }
}
