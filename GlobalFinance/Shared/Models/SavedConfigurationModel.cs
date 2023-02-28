using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GlobalFinance.Shared.Models
{
	public class SavedConfigurationModel
	{
		[Required, Key]
		public int SavedConfigurationId { get; set; }
		[Required]
		public int PaintId { get; set; }
		[Required]
		public int ModelVariantId { get; set; }
		[Required]
		public int CarId { get; set; }

		public PaintModel? Paint { get; set; }
		public ModelVariantModel? ModelVariant { get; set; }
		public CarModel? Car { get; set; }

	}
}

