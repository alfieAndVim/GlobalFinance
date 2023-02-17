﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
	public class Customer
	{
		[Required, Key]
		public int CustomerId { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string AddressFirstLine { get; set; }
		public string AddressSecondLine { get; set; }
		public object AddressThirdLine { get; set; }
		[Required]
		public string AddressPostcode { get; set; }
		[Required]
		public int ContactNumber { get; set; }
		[Required]
		public int UserId { get; set; }

		public User? User { get; set; }
	}
}

