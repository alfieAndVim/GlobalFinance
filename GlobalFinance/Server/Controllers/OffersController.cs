using GlobalFinance.Server.Data;
using GlobalFinance.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace GlobalFinance.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OffersController : ControllerBase
    {
        private readonly PublicDataContext publicDataContext;

        public OffersController(PublicDataContext publicDataContext)
        {
            this.publicDataContext = publicDataContext;
        }
        

        [HttpGet("list")]
        public async Task<ActionResult<List<OfferModel>>> List()
        {
            var _offers = await publicDataContext.Offers.ToListAsync();
            return Ok(_offers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferModel>> Get(int id)
        {
            var _offer = await publicDataContext.Offers.FirstOrDefaultAsync(o => o.OfferId == id);
            if (_offer is not null)
            {
                return Ok(_offer);
            }
            return NotFound();
        }
    }
}
