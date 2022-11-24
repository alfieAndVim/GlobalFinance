using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
	public class PaintModel
	{
        [Required, Key]
        public int PaintId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int PriceIncrease { get; set; }

        [Required]
        public int CarId { get; set; }

        public CarModel? Car { get; set; }
    }
}

