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
    public class ConfiguratorController : ControllerBase
    {
        private readonly AppDataContext appDataContext;

        public ConfiguratorController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpPost("post_configuration")]
        public ActionResult<int> PostConfiguration(SavedConfigurationModel savedConfiguration)
        {
            appDataContext.Add(savedConfiguration);
            appDataContext.SaveChanges();
            return Ok(savedConfiguration.SavedConfigurationId);
        }

        [HttpGet("{savedConfigurationId}")]
        public async Task<ActionResult<SavedConfigurationModel>> GetConfiguration(int savedConfigurationId)
        {
            var response = await appDataContext.SavedConfigurations
                .Include(S => S.Customisation)
                    .ThenInclude(C => C.Car)
                .Include(S => S.Customisation)
                    .ThenInclude(C => C.ModelVariant)
                .Include(S => S.Customisation)
                    .ThenInclude(C => C.Paint)
                .FirstOrDefaultAsync(S => S.SavedConfigurationId == savedConfigurationId);
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

