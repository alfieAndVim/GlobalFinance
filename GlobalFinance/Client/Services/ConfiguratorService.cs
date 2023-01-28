using System;
using GlobalFinance.Client.ServicesInterfaces;
using GlobalFinance.Shared.Models;
using Microsoft.Extensions.Configuration;

namespace GlobalFinance.Client.Services
{
    public class ConfiguratorService : IConfiguratorService
    {
        private readonly HttpClient httpClient;

        public ConfigurationModel Configuration { get; set; } = new ConfigurationModel();

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

        public double GetFinanceAmount(int totalMonths = 36, int initialPayment = 0, int interestRate = 4)
        {
            var _totalPrice = Configuration.Price.HasValue ? (double)Configuration.Price : 0.0;
            return Math.Round(((_totalPrice - initialPayment) / totalMonths) * (1 + (interestRate / 100)), 2);

        }
    }
}

