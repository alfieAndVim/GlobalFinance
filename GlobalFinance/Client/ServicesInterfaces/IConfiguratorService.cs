﻿using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IConfiguratorService
    {
        ConfigurationModel Configuration { get; set; }
        SavedConfigurationModel SavedConfiguration { get; set; }

        List<ConfiguratorOptionModel> ConvertModelVariantToOption(List<ModelVariantModel> modelVariants);
        List<ConfiguratorOptionModel> ConvertPaintToOption(List<PaintModel> paints);
        double GetFinanceAmount(int totalMonths = 48, int initialPayment = 4000, int interestRate = 4);
        ConfigurationModel GetOrSetConfiguration(CarModel carResult);
        void SetConfigurationModelVariant(ModelVariantModel modelVariant);
    }
}