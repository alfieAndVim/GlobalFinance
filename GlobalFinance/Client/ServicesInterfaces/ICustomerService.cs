using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.Services
{
    public interface ICustomerService
    {
        CustomerModel customer { get; set; }

        Task<int> AddCustomer(CustomerModel customer);
        Task<CustomerModel> GetCustomer(int customerId);
    }
}