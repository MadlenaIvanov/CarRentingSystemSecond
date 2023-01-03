using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemSecond.Data.Models
{
    public class Sale
    {
        public int Id { get; init; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }
    }
}
