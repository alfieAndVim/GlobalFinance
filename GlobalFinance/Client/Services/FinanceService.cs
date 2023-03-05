using System;
using System.Net.Http.Json;
using GlobalFinance.Shared.Models;
namespace GlobalFinance.Client.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly HttpClient httpClient;

        public FinanceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public FinanceModel Finance { get; set; } = new FinanceModel();

        public async Task<int> AddFinance(FinanceModel finance)
        {
            var response = await httpClient.PostAsJsonAsync("finance/post_finance", finance);
            if (response != null)
            {
                return Convert.ToInt32(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Could not add finance");
            }
        }

        public async Task<FinanceModel> GetFinance(int enquiryId)
        {
            var response = await httpClient.GetFromJsonAsync<FinanceModel>($"finance/{enquiryId}");
            Console.WriteLine(response);
            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("Could not get finances");
            }
        }

        public async Task<int> UpdateFinance(FinanceModel finance)
        {
            var response = await httpClient.PostAsJsonAsync("finance/update", finance);
            if (response.IsSuccessStatusCode)
            {
                return 0;
            }
            else
            {
                throw new Exception("Could not remove finance");
            }
        }

        public async Task<int> RemoveFinance(FinanceModel finance)
        {
            var response = await httpClient.PostAsJsonAsync("finance/remove", finance);
            if (response.IsSuccessStatusCode)
            {
                return 0;
            }
            else
            {
                throw new Exception("Could not remove finance");
            }
        }
    }
}

