using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GlobalFinance.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalFinance.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FinanceDocumentController : Controller
    {
        private readonly AppDataContext appDataContext;

        public FinanceDocumentController(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        [HttpPost("post_documents")]
        public async Task<ActionResult<List<FinanceDocumentModel>>> PostFile(List<FinanceDocumentDto> files)
        {
            List<FinanceDocumentModel> uploadedFiles = new List<FinanceDocumentModel>();

            List<FinanceDocumentDto> formFiles = files;

            foreach (var f in formFiles)

            {
                
                var document = new FinanceDocumentModel();
                string trustedFileNameForFileStorage;
                var untrustedFileName = f.FileName;
                document.FileName = untrustedFileName;
                var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                trustedFileNameForFileStorage = Path.GetRandomFileName();

                FinanceDocumentModel databaseDocument = new FinanceDocumentModel();
                databaseDocument.FileName = trustedFileNameForDisplay;
                databaseDocument.StoredFileName = trustedFileNameForFileStorage;
                databaseDocument.ContentType = f.ContentType;
                databaseDocument.FileContent = Convert.FromBase64String(f.Base64FileContent);
                databaseDocument.FinanceId = f.FinanceId;

                appDataContext.Add(databaseDocument);
                appDataContext.SaveChanges();
            }

            return Ok(uploadedFiles);

        }

        [HttpGet("{finance_id}")]
        public async Task<ActionResult<List<FinanceDocumentDto>>> GetFiles(int finance_id)
        {
            List<FinanceDocumentDto> files = new List<FinanceDocumentDto>();
            List<FinanceDocumentModel> storedFiles = new List<FinanceDocumentModel>();

            var response = await appDataContext.FinanceDocuments.Where(F => F.FinanceId == finance_id).ToListAsync();

            foreach (FinanceDocumentModel file in response)
            {
                FinanceDocumentDto transferableFile = new FinanceDocumentDto();

                transferableFile.FileName = file.StoredFileName;
                transferableFile.UntrustedFileName = file.FileName;
                transferableFile.Base64FileContent = Convert.ToBase64String(file.FileContent);
                transferableFile.ContentType = file.ContentType;
                transferableFile.FinanceId = file.FinanceId;
                files.Add(transferableFile);
            }

            if (files != null)
            {
                return Ok(files);
            } else {
                return BadRequest();
            }
        }
    }
}

