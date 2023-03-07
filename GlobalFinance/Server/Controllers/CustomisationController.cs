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
    [ApiController]
    [Route("[Controller]")]
    public class CustomisationController : ControllerBase
    {
        private readonly AppDataContext appDataContext;

        public CustomisationController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpPost("post_customisation")]
        public ActionResult<int> PostCustomisation(CustomisationModel customisation)
        {
            appDataContext.Add(customisation);
            appDataContext.SaveChanges();
            return Ok(customisation.CustomisationId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomisationModel>> Get(int customisationId)
        {
            var response = await appDataContext.Customisations.FirstOrDefaultAsync(C => C.CustomisationId == customisationId);
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

