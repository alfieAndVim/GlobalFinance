using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		[Required, ForeignKey("Customisation")]
		public int CustomisationId { get; set; }

		public CustomisationModel? Customisation { get; set; }


	}
}

