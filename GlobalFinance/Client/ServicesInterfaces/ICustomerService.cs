using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface ICustomerService
    {
        Customer customer { get; set; }

        Task<int> AddCustomer(Customer customer);
    }
}