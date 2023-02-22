using System;
using System.ComponentModel.DataAnnotations;
namespace GlobalFinance.Shared.Models
{
	public class InventoryModel
	{
		[Required, Key]
		public int InventoryId { get; set; }
		[Required]
		public int InventoryMileage { get; set; }
		[Required]
		public int InventoryPrice { get; set; }
		[Required]
		public int CarId { get; set; }

		public CarModel? Car { get; set; }
	}
}

