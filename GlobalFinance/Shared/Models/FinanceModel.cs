using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GlobalFinance.Shared.Models
{
	public class FinanceModel
	{
		[Required, Key]
		public int FinanceId { get; set; }
		[Required]
		public double FinancePrice { get; set; }
		[Required]
		public double FinanceInterestRate { get; set; }
		[Required]
		public int FinanceMonths { get; set; }
		[Required]
		public double FinanceInitialPayment { get; set; }
		[Required]
		public int OrderId { get; set; }

		public OrderModel? Order { get; set; }

	}
}

