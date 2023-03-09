using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
    //Model to represent an individual car
    public class CarModel
    {
        //Required Id for each car
        [Required, Key]
        public int CarId { get; set; }
        //Required make name for each car
        [Required]
        public string CarMakeName { get; set; } = string.Empty;
        //Required model name for each car
        [Required]
        public string CarModelName { get; set; } = string.Empty;
        //Required starting price as a finance monthly payment
        [Required]
        public int CarStartingPrice { get; set; }
        //Outright starting price to represent a cars full purchase amount
        public int CarOutrightStartingPrice { get; set; }


    }
}

