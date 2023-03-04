using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GlobalFinance.Server.Data;
using Microsoft.AspNetCore.Mvc;


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
                databaseDocument.FinanceId = 1;

                appDataContext.Add(databaseDocument);
                appDataContext.SaveChanges();
            }

            return Ok(uploadedFiles);

        }
    }
}

