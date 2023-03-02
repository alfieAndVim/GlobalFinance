using System;
using GlobalFinance.Shared.Models;
namespace GlobalFinance.Client.Services
{
    public class EnquiryService : IEnquiryService
    {
        private readonly HttpClient httpClient;

        public EnquiryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public EnquiryModel Enquiry { get; set; } = new EnquiryModel();
    }
}

