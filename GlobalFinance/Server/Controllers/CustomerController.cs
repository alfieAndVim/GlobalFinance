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
        public ActionResult<int> PostInformation(Customer customer)
        {
            appDataContext.Add(customer);
            appDataContext.SaveChanges();
            return Ok(customer.CustomerId);
        }
        
    }
}

