using GlobalFinance.Client.ServicesInterfaces;
using GlobalFinance.Shared.Models;
using Microsoft.Extensions.Configuration;
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

        //Method to perform a HTTP request to the Car Controller
        public async Task GetCars()
        {
            //Gets result through the httpClient module as a list of CarModel
            var result = await httpClient.GetFromJsonAsync<List<CarModel>>("cars/list");
            if (result != null)
            {
                //Return the list if the result was not null
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

        public async Task<ModelVariantModel> GetModel(int id)
        {
            var result = await httpClient.GetFromJsonAsync<ModelVariantModel>($"cars/single_variant{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Could not find model");
        }

        public async Task GetPaints(int id)
        {
            var result = await httpClient.GetFromJsonAsync<List<PaintModel>>($"cars/paints{id}");
            if (result != null)
            {
                Paints = result;
            }
        }

        public async Task<PaintModel> GetPaint(int id)
        {
            var result = await httpClient.GetFromJsonAsync<PaintModel>($"cars/single_paint{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Could not find paint");
        }

        public async Task Update(CarModel car)
        {
            var response = await httpClient.PostAsJsonAsync("cars/update", car);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not update car");
            }
        }

        public double GetFinancePrice(double price, int totalMonths, double initialPayment, int interestRate)
        {
            var amountToPay = price - initialPayment;
            var monthlyPayment = amountToPay / totalMonths;
            var monthlyPaymentWithInterest = monthlyPayment * ((interestRate * 0.1) + 1);
            return Math.Round(monthlyPaymentWithInterest, 2);
        }


    }
}
