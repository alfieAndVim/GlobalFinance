using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalFinance.Shared.Models
{
	public class CustomisationModel
	{
		[Required, Key]
		public int CustomisationId { get; set; }
		[Required, ForeignKey("Car")]
		public int CarId { get; set; }
		[Required, ForeignKey("ModelVariant")]
		public int ModelVariantId { get; set; }
		[Required, ForeignKey("Paint")]
		public int PaintId { get; set; }

		public CarModel? Car { get; set; }
		public ModelVariantModel? ModelVariant { get; set; }
		public PaintModel? Paint { get; set; }

	}
}

