using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface ICarService
    {
        List<CarModel> Cars { get; set; }
        List<ModelVariantModel> ModelVariants { get; set; }

        Task GetCars();
        Task GetModels(int id);
        Task<CarModel> GetSingleCar(int id);
    }
}