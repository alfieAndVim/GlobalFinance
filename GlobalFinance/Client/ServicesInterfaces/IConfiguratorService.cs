using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IConfiguratorService
    {
        ConfigurationModel Configuration { get; set; }

        List<ConfiguratorOptionModel> ConvertModelVariantToOption(List<ModelVariantModel> modelVariants);
        List<ConfiguratorOptionModel> ConvertPaintToOption(List<PaintModel> paints);
        void SetConfigurationModelVariant(ModelVariantModel modelVariant);
    }
}