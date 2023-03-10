using System;
using System.Net.Http.Json;
using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.Services
{
    public class CustomisationService : ICustomisationService
    {
        private readonly HttpClient httpClient;

        public CustomisationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> AddCustomisation(CustomisationModel customisation)
        {
            var result = await httpClient.PostAsJsonAsync("customisation/post_customisation", customisation);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Could not post customisation");
            }
            else
            {
                return Convert.ToInt32(await result.Content.ReadAsStringAsync());
            }
        }
    }
}

