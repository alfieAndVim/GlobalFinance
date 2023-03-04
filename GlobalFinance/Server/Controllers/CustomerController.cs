using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlobalFinance.Server.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlobalFinance.Server.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDataContext appDataContext;

        public CustomerController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpPost("post_information")]
        public ActionResult<int> PostInformation(CustomerModel customer)
        {
            appDataContext.Add(customer);
            appDataContext.SaveChanges();
            return Ok(customer.CustomerId);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerModel>> GetInformation(int customerId)
        {
            var result = await appDataContext.Customers.FirstOrDefaultAsync(C => C.CustomerId == customerId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<CustomerModel>>> ListCustomers()
        {
            var result = await appDataContext.Customers.ToListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}

