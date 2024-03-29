﻿using System;
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
            var inventory = await appDataContext.Inventory
                .Include(I => I.Customisation)
                    .ThenInclude(C => C.Car)
                .Include(I => I.Customisation)
                    .ThenInclude(C => C.ModelVariant)
                .Include(I => I.Customisation)
                    .ThenInclude(C => C.Paint)
                .ToListAsync();
            if (inventory != null)
            {
                return Ok(inventory);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryModel>> Get(int id)
        {
            var inventoryItem = await appDataContext.Inventory
                .Include(I => I.Customisation)
                    .ThenInclude(C => C.Car)
                .Include(I => I.Customisation)
                    .ThenInclude(C => C.ModelVariant)
                .Include(I => I.Customisation)
                    .ThenInclude(C => C.Paint)
                .FirstOrDefaultAsync(I => I.InventoryId == id);
            if (inventoryItem != null)
            {
                return Ok(inventoryItem);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(InventoryModel inventory)
        {
            InventoryModel oldInventory = await appDataContext.Inventory.Include(I => I.Customisation).FirstOrDefaultAsync(I => I.InventoryId == inventory.InventoryId);
            if (oldInventory != null)
            {
                oldInventory.InventoryMileage = inventory.InventoryMileage;
                oldInventory.InventoryPrice = inventory.InventoryPrice;
                oldInventory.Customisation.PaintId = inventory.Customisation.PaintId;
                oldInventory.Customisation.ModelVariantId = inventory.Customisation.ModelVariantId;
            }
            appDataContext.SaveChanges();
            return Ok();
        }

        [HttpPost("add")]
        public ActionResult Add(InventoryModel inventory)
        {
            CustomisationModel customisation = new CustomisationModel { CarId = inventory.Customisation.CarId, ModelVariantId = inventory.Customisation.ModelVariantId, PaintId = inventory.Customisation.PaintId };
            appDataContext.Add(customisation);
            appDataContext.SaveChanges();
            InventoryModel newInventory = new InventoryModel { CustomisationId = customisation.CustomisationId, InventoryMileage = inventory.InventoryMileage, InventoryPrice = inventory.InventoryPrice };
            appDataContext.Inventory.Add(newInventory);
            appDataContext.SaveChanges();
            return Ok();
        }
    }
}

