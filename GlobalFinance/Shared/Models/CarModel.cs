using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
    public class CarModel
    {
        [Required, Key]
        public int CarId { get; set; }
        [Required]
        public string CarMakeName { get; set; } = string.Empty;
        [Required]
        public string CarModelName { get; set; } = string.Empty;
        [Required]
        public int CarStartingPrice { get; set; }
        public int CarOutrightStartingPrice { get; set; }

    }
}
