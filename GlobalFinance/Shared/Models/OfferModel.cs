using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
    public class OfferModel
    {
        [Required]
        public int OfferId { get; set; }
        [Required]
        public string OfferTitle { get; set; } = string.Empty;
        [Required]
        public string OfferExpiry { get; set; } = string.Empty;
        [Required]
        public int CarId { get; set; }
    }
}
