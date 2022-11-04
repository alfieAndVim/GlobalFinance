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
        public DateOnly OfferExpiry { get; set; }
        [Required]
        public int CarId { get; set; }
    }
}
