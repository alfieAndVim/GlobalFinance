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
		[Required]
        public int ModelVariantId { get; set; }
		[Required]
		public int PaintId { get; set; }

        public CarModel? Car { get; set; }
	}
}

