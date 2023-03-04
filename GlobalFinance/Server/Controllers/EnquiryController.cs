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
    }
}

