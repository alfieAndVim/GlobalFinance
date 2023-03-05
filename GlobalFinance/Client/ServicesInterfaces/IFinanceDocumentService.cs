using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.Services
{
    public interface IFinanceDocumentService
    {
        List<FinanceDocumentDto> financeDocumentDtos { get; set; }

        Task<List<FinanceDocumentModel>> DownloadDocuments(int financeId);
        Task<List<FinanceDocumentModel>> UploadDocuments(List<FinanceDocumentDto> documents);
    }
}