using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.Services
{
    public interface IInventoryService
    {
        List<InventoryModel> Inventory { get; set; }
        InventoryModel InventoryCar { get; set; }

        Task GetInventory();
        Task<InventoryModel> GetSingleInventoryItem(int id);
    }
}