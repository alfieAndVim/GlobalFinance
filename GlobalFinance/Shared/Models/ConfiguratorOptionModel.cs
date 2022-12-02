using System;
namespace GlobalFinance.Shared.Models
{
	public class ConfiguratorOptionModel
	{
		public int OptionId { get; set; }
		public string OptionName { get; set; } = string.Empty;
		public int OptionPriceIncrease { get; set; }

	}
}

