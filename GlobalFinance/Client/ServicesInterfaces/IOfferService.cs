using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IOfferService
    {
        List<OfferModel> Offers { get; set; }

        Task GetOffers();
    }
}