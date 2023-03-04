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
    public class FinanceController : ControllerBase
    {
        private readonly AppDataContext appDataContext;

        public FinanceController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpPost("post_finance")]
        public ActionResult<int> PostFinance(FinanceModel finance)
        {
            appDataContext.Add(finance);
            appDataContext.SaveChanges();
            return Ok(finance.FinanceId);
        }

        [HttpGet("{enquiryId}")]
        public async Task<ActionResult<FinanceModel>> GetFinance(int enquiryId)
        {
            var response = await appDataContext.Finances.FirstOrDefaultAsync(F => F.EnquiryId == enquiryId);
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

