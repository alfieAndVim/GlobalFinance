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
    }
}

