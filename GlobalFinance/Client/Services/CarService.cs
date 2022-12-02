using GlobalFinance.Client.ServicesInterfaces;
using GlobalFinance.Shared.Models;
using System.Net.Http.Json;

namespace GlobalFinance.Client.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient httpClient;

        public CarService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<CarModel> Cars { get; set; } = new List<CarModel>();
        public List<ModelVariantModel> ModelVariants { get; set; } = new List<ModelVariantModel>();
        public List<PaintModel> Paints { get; set; } = new List<PaintModel>();

        public async Task GetCars()
        {
            var result = await httpClient.GetFromJsonAsync<List<CarModel>>("cars/list");
            if (result != null)
            {
                Cars = result;
            }

        }

        public async Task<CarModel> GetSingleCar(int id)
        {
            var result = await httpClient.GetFromJsonAsync<CarModel>($"cars/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Car could not be found");
        }

        public async Task GetModels(int id)
        {
            var result = await httpClient.GetFromJsonAsync<List<ModelVariantModel>>($"cars/variants{id}");
            if (result != null)
            {
                ModelVariants = result;
            }
        }

        public async Task GetPaints(int id)
        {
            var result = await httpClient.GetFromJsonAsync<List<PaintModel>>($"cars/paints{id}");
            if (result != null)
            {
                Paints = result;
            }
        }


    }
}
