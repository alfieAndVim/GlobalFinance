using GlobalFinance.Server.Data;
using GlobalFinance.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalFinance.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarsController : ControllerBase
    {
        private readonly PublicDataContext publicDataContext;

        public CarsController(PublicDataContext publicDataContext)
        {
            this.publicDataContext = publicDataContext;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<CarModel>>> List()
        {
            var _cars = await publicDataContext.Cars.ToListAsync();
            return Ok(_cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> Get(int id)
        {
            var _car = await publicDataContext.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            if(_car is not null)
            {
                return Ok(_car);
            }
            return NotFound();
        }

        [HttpGet("variants{id}")]
        public async Task<ActionResult<List<ModelVariantModel>>> ListVariants(int id)
        {
            var _variants = await publicDataContext.ModelVariants.Where(v => v.CarId == id).ToListAsync();
            return Ok(_variants);
        }
        

    }
}
