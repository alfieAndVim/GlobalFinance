using System;
using System.ComponentModel.DataAnnotations;
namespace GlobalFinance.Shared.Models
{
	public class OrderModel
	{
		[Required, Key]
		public int OrderId { get; set; }
		[Required]
		public int ConfigurationId { get; set; }
		[Required]
		ConfigurationModel? Configuration { get; set; }
	}
}

