using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GlobalFinance.Shared.Models
{
	public class EnquiryModel
	{
		[Required, Key]
		public int EnquiryId { get; set; }
		[Required]
		public int CustomerId { get; set; }

		[ForeignKey("SavedConfiguration")]
		public int? SavedConfigurationId { get; set; } = null!;
		[ForeignKey("InventoryModel")]
		public int? InventoryId { get; set; } = null!;

		public CustomerModel? Customer { get; set; }
		public SavedConfigurationModel? SavedConfiguration { get; set; }
		public InventoryModel? InventoryModel { get; set; }
	}
}

