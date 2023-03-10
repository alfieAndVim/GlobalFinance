using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface ICustomisationService
    {
        Task<int> AddCustomisation(CustomisationModel customisation);
    }
}