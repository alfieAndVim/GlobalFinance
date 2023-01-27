using GlobalFinance.Client.Services;
using GlobalFinance.Shared.Models;
namespace GlobalFinance.Tests;


[TestClass]
public class ConfigurationServiceUnitTest
{
    [TestMethod]
    public void CheckMonthlyPrice()
    {
        var tempHttpClient = new HttpClient();

        ConfiguratorService configuratorService = new ConfiguratorService(tempHttpClient);

        var tempConfiguration = new ConfigurationModel();
        tempConfiguration.Price = 12000;
        configuratorService.Configuration = tempConfiguration;

        var deposit = 2000;
        var months = 36;
        var interestRate = 4;
        var expectedMonthlyPrice = 277.78;
        Assert.AreEqual(expectedMonthlyPrice, configuratorService.GetFinanceAmount(totalMonths: months, initialPayment: deposit, interestRate: interestRate));
        
    }
}
