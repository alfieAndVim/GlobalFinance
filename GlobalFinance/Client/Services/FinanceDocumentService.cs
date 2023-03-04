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
            if (!response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<FinanceDocumentModel>>();
            }
            else
            {
                throw new Exception("Could not upload documents");
            }
        }
    }
}

