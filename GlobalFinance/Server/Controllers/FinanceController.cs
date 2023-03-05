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

        [HttpPost("update")]
        public ActionResult UpdateFinance(FinanceModel finance)
        {
            appDataContext.Finances.Update(finance);
            appDataContext.SaveChanges();
            return Ok();
        }

        [HttpPost("remove")]
        public async Task<ActionResult> RemoveFinance(FinanceModel finance)
        {
            List<FinanceDocumentModel> financeDocuments = await appDataContext.FinanceDocuments.Where(D => D.FinanceId == finance.FinanceId).ToListAsync();
            financeDocuments.ForEach(F => appDataContext.FinanceDocuments.Remove(F));
            appDataContext.Finances.Remove(finance);
            appDataContext.Orders.Remove(finance.Enquiry);
            appDataContext.SaveChanges();
            return Ok();
        }
    }
}

