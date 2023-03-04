using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface ICustomerService
    {
        CustomerModel customer { get; set; }

        Task<int> AddCustomer(CustomerModel customer);
        Task<CustomerModel> GetCustomer(int customerId);
        Task<List<CustomerModel>> GetCustomers();
    }
}