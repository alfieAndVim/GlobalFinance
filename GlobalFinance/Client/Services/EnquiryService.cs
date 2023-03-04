using System;
using System.Net.Http.Json;
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

        public async Task<int> AddEnquiry(EnquiryModel enquiry)
        {
            var response = await httpClient.PostAsJsonAsync("enquiry/post_enquiry", enquiry);
            if (response != null)
            {
                return Convert.ToInt32(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Could not add enquiry");
            }
        }

        public async Task<List<EnquiryModel>> GetEnquiries(int customerId)
        {
            var response = await httpClient.GetFromJsonAsync<List<EnquiryModel>>($"enquiry/list/{customerId}");
            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("Could not get enquiries");
            }
        }
    }
}

