using System;
namespace GlobalFinance.Shared.Models
{
	public class ConfigurationModel
	{
		public int ConfigurationId { get; set; }
		public int? CarId { get; set; }
		public int? ModelVariantId { get; set; }
		public int? PaintId { get; set; }
		public int? Price { get; set; }
		public Stack<ConfiguratorOptionModel>? Options { get; set; }

	}
}

