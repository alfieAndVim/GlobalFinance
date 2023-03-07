using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.Services
{
    public interface ICarService
    {
        List<CarModel> Cars { get; set; }
        List<ModelVariantModel> ModelVariants { get; set; }
        List<PaintModel> Paints { get; set; }

        Task GetCars();
        double GetFinancePrice(double price, int totalMonths, double initialPayment, int interestRate);
        Task<ModelVariantModel> GetModel(int id);
        Task GetModels(int id);
        Task<PaintModel> GetPaint(int id);
        Task GetPaints(int id);
        Task<CarModel> GetSingleCar(int id);
        Task Update(CarModel car);
    }
}