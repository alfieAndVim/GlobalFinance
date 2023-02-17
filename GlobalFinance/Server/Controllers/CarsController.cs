﻿using GlobalFinance.Server.Data;
using GlobalFinance.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalFinance.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AppDataContext appDataContext;

        public CarsController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<CarModel>>> List()
        {
            var _cars = await appDataContext.Cars.ToListAsync();
            return Ok(_cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> Get(int id)
        {
            var _car = await appDataContext.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            if(_car is not null)
            {
                return Ok(_car);
            }
            return NotFound();
        }

        [HttpGet("variants{id}")]
        public async Task<ActionResult<List<ModelVariantModel>>> ListVariants(int id)
        {
            var _variants = await appDataContext.ModelVariants.Where(v => v.CarId == id).ToListAsync();
            return Ok(_variants);
        }

        [HttpGet("paints{id}")]
        public async Task<ActionResult<List<PaintModel>>> ListPaints(int id)
        {
            var _paints = await appDataContext.PaintColours.Where(p => p.CarId == id).ToListAsync();
            return Ok(_paints);
        }
        

    }
}
