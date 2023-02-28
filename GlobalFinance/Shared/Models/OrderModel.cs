using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GlobalFinance.Shared.Models
{
	public class OrderModel
	{
		[Required, Key]
		public int OrderId { get; set; }
		[Required]
		public int CustomerId { get; set; }

		public int SavedConfigurationId { get; set; }
		public int InventoryId { get; set; }

		public CustomerModel? Customer { get; set; }
		public SavedConfigurationModel? SavedConfiguration { get; set; }
		public InventoryModel? inventoryModel { get; set; }
	}
}

