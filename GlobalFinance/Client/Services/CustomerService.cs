using System;
using System.Net.Http.Json;
using GlobalFinance.Shared.Models;
namespace GlobalFinance.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient httpClient;

        public Customer customer { get; set; } = new Customer();

        public CustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            var result = await httpClient.PostAsJsonAsync("customer/post_information", customer);

            if (!result.IsSuccessStatusCode)
            {
                return -1;
            }
            else
            {
                var customerId = await result.Content.ReadAsStringAsync();
                return Convert.ToInt32(customerId);
            }

        }
    }
}

