using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IInventoryService
    {
        List<InventoryModel> Inventory { get; set; }
        InventoryModel InventoryCar { get; set; }

        Task GetInventory();
        Task<InventoryModel> GetSingleInventoryItem(int id);
        Task UpdateInventoryItem(InventoryModel inventory);
    }
}