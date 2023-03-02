using System;
using GlobalFinance.Shared.Models;
using System.Net.Http.Json;

namespace GlobalFinance.Client.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient httpClient;

        public InventoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<InventoryModel> Inventory { get; set; } = new List<InventoryModel>();
        public InventoryModel InventoryCar { get; set; } = new InventoryModel();

        public async Task GetInventory()
        {
            var result = await httpClient.GetFromJsonAsync<List<InventoryModel>>("inventory/list");
            if (result != null)
            {
                Inventory = result;
            }
        }

        public async Task<InventoryModel> GetSingleInventoryItem(int id)
        {
            var result = await httpClient.GetFromJsonAsync<InventoryModel>($"inventory/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Inventory item could not be found");
        }
    }
}

