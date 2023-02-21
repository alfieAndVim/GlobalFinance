using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
	public class User
	{
		[Required, Key]
		public int UserId { get; set; }
		[Required]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string PasswordHash { get; set; } = string.Empty;
		[Required]
		public int CustomerId { get; set; }

		public Customer? customer { get; set; }
	}
}

