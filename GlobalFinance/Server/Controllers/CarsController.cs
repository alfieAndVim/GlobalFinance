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

        //private List<CarModel> _cars = new()
        //{
        //    new() {CarId=0, CarMakeName="Vauxhall", CarModelName="Corsa", CarStartingPrice=400},
        //        new() {CarId=1, CarMakeName="Vauxhall", CarModelName="Astra", CarStartingPrice=450},
        //        new() {CarId=2, CarMakeName="Vauxhall", CarModelName="Mokka", CarStartingPrice=450},
        //        new() {CarId=3, CarMakeName="Vauxhall", CarModelName="Grandland", CarStartingPrice = 450},
        //        new() {CarId=4, CarMakeName="BMW", CarModelName="3-Series", CarStartingPrice=500},
        //        new() {CarId=5, CarMakeName="BMW", CarModelName="4-Series", CarStartingPrice=550},
        //        new() {CarId=6, CarMakeName="BMW", CarModelName="5-Series", CarStartingPrice=600},
        //        new() {CarId=7, CarMakeName="BMW", CarModelName="7-series", CarStartingPrice=700},
        //        new() {CarId=8, CarMakeName="Audi", CarModelName="A1", CarStartingPrice=300},
        //        new() {CarId=9, CarMakeName="Audi", CarModelName="A3", CarStartingPrice=400},
        //        new() {CarId=10, CarMakeName="Audi", CarModelName="A4", CarStartingPrice=500},
        //        new() {CarId=11, CarMakeName="Audi", CarModelName="A5", CarStartingPrice=500},
        //        new() {CarId=12, CarMakeName="Audi", CarModelName="A6", CarStartingPrice=550},
        //        new() {CarId=13, CarMakeName="Audi", CarModelName="A7", CarStartingPrice=600},
        //        new() {CarId=14, CarMakeName="Audi", CarModelName="A8", CarStartingPrice=750},
        //};

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
        

    }
}
