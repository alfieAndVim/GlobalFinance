using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalFinance.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalFinance.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnquiryController : ControllerBase
    {
        private readonly AppDataContext appDataContext;

        public EnquiryController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpPost("post_enquiry")]
        public ActionResult<int> PostConfiguration(EnquiryModel enquiry)
        {
            appDataContext.Add(enquiry);
            appDataContext.SaveChanges();
            return Ok(enquiry.EnquiryId);
        }

        [HttpGet("list/{customerId}")]
        public async Task<ActionResult<List<EnquiryModel>>> GetEnquiries(int customerId)
        {
            var response = await appDataContext.Orders.Where(E => E.CustomerId == customerId).ToListAsync();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<EnquiryModel>>> GetAllEnquiries()
        {
            //var response = new List<EnquiryModel>();
            //List<EnquiryModel> savedConfigurationEnquiries = await appDataContext.Orders.Where(E => E.SavedConfigurationId != null).Include(E => E.SavedConfiguration).Include(E => E.Customer).Include(E => E.SavedConfiguration.Car).ToListAsync();
            //List<EnquiryModel> inventoryEnquiries = await appDataContext.Orders.Where(E => E.InventoryId != null).Include(E => E.inventoryModel).Include(E => E.Customer).Include(E => E.inventoryModel.Car).ToListAsync();
            //savedConfigurationEnquiries.ForEach(S => response.Add(S));
            //inventoryEnquiries.ForEach(I => response.Add(I));

            var response = await appDataContext.Orders
                .Include(O => O.SavedConfiguration).ThenInclude(S => S.Customisation)
                    .ThenInclude(C => C.Car)
                .Include(O => O.SavedConfiguration).ThenInclude(S => S.Customisation)
                    .ThenInclude(C => C.ModelVariant)
                .Include(O => O.SavedConfiguration).ThenInclude(S => S.Customisation)
                    .ThenInclude(C => C.Paint)
                .Include(O => O.InventoryModel).ThenInclude(I => I.Customisation)
                    .ThenInclude(C => C.Car)
                .Include(O => O.InventoryModel).ThenInclude(I => I.Customisation)
                    .ThenInclude(C => C.ModelVariant)
                .Include(O => O.InventoryModel).ThenInclude(I => I.Customisation)
                    .ThenInclude(C => C.Paint)
                .Include(O => O.Customer)
                .ToListAsync(); 

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

