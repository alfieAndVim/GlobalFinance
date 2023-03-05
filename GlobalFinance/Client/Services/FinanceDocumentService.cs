using System;
using System.Net.Http.Json;
using GlobalFinance.Shared.Models;
namespace GlobalFinance.Client.Services
{
    public class FinanceDocumentService : IFinanceDocumentService
    {
        private readonly HttpClient httpClient;

        public FinanceDocumentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<FinanceDocumentDto> financeDocumentDtos { get; set; } = new List<FinanceDocumentDto>();

        public async Task<List<FinanceDocumentModel>> UploadDocuments(List<FinanceDocumentDto> documents)
        {
            var response = await httpClient.PostAsJsonAsync("financedocument/post_documents", documents);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<FinanceDocumentModel>>();
            }
            else
            {
                throw new Exception("Could not upload documents");
            }
        }

        public async Task<List<FinanceDocumentModel>> DownloadDocuments(int financeId)
        {
            var response = await httpClient.GetFromJsonAsync<List<FinanceDocumentDto>>($"financedocument/{financeId}");
            if (response != null)
            {
                List<FinanceDocumentModel> returningFiles = new List<FinanceDocumentModel>();
                foreach (FinanceDocumentDto file in response)
                {
                    FinanceDocumentModel returningFile = new FinanceDocumentModel();
                    returningFile.ContentType = file.ContentType;
                    returningFile.FileName = file.FileName;
                    returningFile.FileContent = Convert.FromBase64String(file.Base64FileContent);
                    returningFile.FinanceId = file.FinanceId;

                    returningFiles.Add(returningFile);
                }

                return returningFiles;
            }
            else
            {
                throw new Exception("Could not get documents");
            }
        }
    }
}

