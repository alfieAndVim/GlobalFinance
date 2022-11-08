using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalFinance.Shared.Models
{
    public class OfferModel
    {
        [Required, Key]
        public int OfferId { get; set; }
        [Required]
        public int OfferPrice { get; set; }
        [Required]
        public string OfferExpiry { get; set; } = string.Empty;
        [Required]
        public int CarId { get; set; }
        
        public CarModel? Car { get; set; }
    }
}
