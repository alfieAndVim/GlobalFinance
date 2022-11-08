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
            var result = await httpClient.GetFromJsonAsync<CarModel>($"Cars/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Car could not be found");
        }
    }
}
