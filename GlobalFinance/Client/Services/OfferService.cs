using GlobalFinance.Client.ServicesInterfaces;
using GlobalFinance.Shared.Models;
using System.Net.Http.Json;

namespace GlobalFinance.Client.Services
{
    public class OfferService : IOfferService
    {
        private readonly HttpClient httpClient;

        public OfferService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<OfferModel> Offers { get; set; } = new List<OfferModel>();

        public async Task GetOffers()
        {
            var result = await httpClient.GetFromJsonAsync<List<OfferModel>>("offers/list");
            if (result != null)
            {
                Offers = result;
            }

        }
    }
}
