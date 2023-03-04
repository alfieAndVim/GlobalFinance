using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalFinance.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlobalFinance.Server.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly AppDataContext appDataContext;

        public InventoryController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<InventoryModel>>> List()
        {
            var inventory = await appDataContext.Inventory.Include(I => I.Car).ToListAsync();
            if (inventory != null)
            {
                return Ok(inventory);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryModel>> Get(int id)
        {
            var inventoryItem = await appDataContext.Inventory.Include(I => I.Car).FirstOrDefaultAsync(I => I.InventoryId == 1);
            if (inventoryItem != null)
            {
                return Ok(inventoryItem);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}

