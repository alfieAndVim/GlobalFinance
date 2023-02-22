using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
	public class CustomerModel
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
		public string AddressThirdLine { get; set; }
		[Required]
		public string AddressPostcode { get; set; }
		[Required]
		[DataType(DataType.PhoneNumber, ErrorMessage = "The contact number must be a valid phone number")]
		public string ContactNumber { get; set; }
	}
}

