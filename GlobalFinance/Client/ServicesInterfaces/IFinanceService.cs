using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IFinanceService
    {
        FinanceModel Finance { get; set; }
    }
}