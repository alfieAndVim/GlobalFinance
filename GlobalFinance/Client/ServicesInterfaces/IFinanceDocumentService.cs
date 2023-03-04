using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IFinanceDocumentService
    {
        List<FinanceDocumentDto> financeDocumentDtos { get; set; }

        Task<List<FinanceDocumentModel>> UploadDocuments(List<FinanceDocumentDto> documents);
    }
}