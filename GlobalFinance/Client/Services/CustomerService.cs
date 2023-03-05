using System;
using System.Net.Http.Json;
using GlobalFinance.Shared.Models;
namespace GlobalFinance.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient httpClient;

        public CustomerModel customer { get; set; } = new CustomerModel();

        public CustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> AddCustomer(CustomerModel customer)
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

        public async Task<CustomerModel> GetCustomer(int customerId)
        {
            var result = await httpClient.GetFromJsonAsync<CustomerModel>($"customer/{customerId}");
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Could not find customer");
            }
        }

        public async Task<List<CustomerModel>> GetCustomers()
        {
            var result = await httpClient.GetFromJsonAsync<List<CustomerModel>>("customer/list");
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Could not get customers");
            }
        }

        public async Task<int> UpdateCustomer(CustomerModel customer)
        {
            var result = await httpClient.PostAsJsonAsync("customer/update", customer);

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