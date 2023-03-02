using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IEnquiryService
    {
        EnquiryModel Enquiry { get; set; }
    }
}