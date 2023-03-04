using System;
using System.Net.Http.Json;
using GlobalFinance.Client.ServicesInterfaces;
using GlobalFinance.Shared.Models;
using Microsoft.Extensions.Configuration;

namespace GlobalFinance.Client.Services
{
    public class ConfiguratorService : IConfiguratorService
    {
        private readonly HttpClient httpClient;

        public ConfigurationModel Configuration { get; set; } = new ConfigurationModel();
        public SavedConfigurationModel SavedConfiguration { get; set; } = new SavedConfigurationModel();

        public ConfiguratorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void SetConfigurationModelVariant(ModelVariantModel modelVariant)
        {
            Configuration.ModelVariantId = modelVariant.ModelVariantId;
        }

        public List<ConfiguratorOptionModel> ConvertModelVariantToOption(List<ModelVariantModel> modelVariants)
        {
            return modelVariants.Select(x => new ConfiguratorOptionModel()
            {
                OptionId = x.ModelVariantId,
                OptionName = x.Name,
                OptionPriceIncrease = x.PriceIncrease
            }).ToList();
        }

        public List<ConfiguratorOptionModel> ConvertPaintToOption(List<PaintModel> paints)
        {
            return paints.Select(x => new ConfiguratorOptionModel()
            {
                OptionId = x.PaintId,
                OptionName = x.Name,
                OptionPriceIncrease = x.PriceIncrease
            }).ToList();
        }

        public ConfigurationModel GetOrSetConfiguration(CarModel carResult)
        {
            if (Configuration.CarId is null)
            {
                Configuration = new ConfigurationModel()
                {
                    ConfigurationId = 0,
                    CarId = carResult.CarId,
                    ModelVariantId = 0,
                    PaintId = 0,
                    Options = new Stack<ConfiguratorOptionModel>(),
                    Price = carResult.CarOutrightStartingPrice
                };
            }
            return Configuration;
        }

        public double GetFinanceAmount(int totalMonths = 48, int initialPayment = 4000, int interestRate = 4)
        {
            var _totalPrice = Configuration.Price.HasValue ? (double)Configuration.Price : 0.0;
            return Math.Round(((_totalPrice - initialPayment) / totalMonths) * (1 + (interestRate / 100)), 2);

        }

        public async Task<int> AddConfiguration(SavedConfigurationModel savedConfiguration)
        {
            var response = await httpClient.PostAsJsonAsync<SavedConfigurationModel>("configurator/post_configuration", savedConfiguration);
            if (response != null)
            {
                return Convert.ToInt32(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("could not save configuration");
            }
        }

        public async Task<SavedConfigurationModel> GetConfiguration(int savedConfigurationId)
        {
            Console.WriteLine("success");
            var response = await httpClient.GetFromJsonAsync<SavedConfigurationModel>($"configurator/{savedConfigurationId}");
            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("Could not get configuration");
            }
        }
    }
}

