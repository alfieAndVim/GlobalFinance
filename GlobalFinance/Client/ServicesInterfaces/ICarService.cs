using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface ICarService
    {
        List<CarModel> Cars { get; set; }

        Task GetCars();
        Task<CarModel> GetSingleCar(int id);
    }
}