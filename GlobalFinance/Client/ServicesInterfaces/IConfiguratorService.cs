using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IConfiguratorService
    {
        ConfigurationModel Configuration { get; set; }

        List<ConfiguratorOptionModel> ConvertModelVariantToOption(List<ModelVariantModel> modelVariants);
        List<ConfiguratorOptionModel> ConvertPaintToOption(List<PaintModel> paints);
        double GetFinanceAmount(int totalMonths = 36, int initialPayment = 0, int interestRate = 4);
        ConfigurationModel GetOrSetConfiguration(CarModel carResult);
        void SetConfigurationModelVariant(ModelVariantModel modelVariant);
    }
}