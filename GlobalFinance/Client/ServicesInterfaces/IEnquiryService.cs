using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IEnquiryService
    {
        EnquiryModel Enquiry { get; set; }

        Task<int> AddEnquiry(EnquiryModel enquiry);
        Task<List<EnquiryModel>> GetAllEnquiries();
        Task<List<EnquiryModel>> GetEnquiries(int customerId);
    }
}