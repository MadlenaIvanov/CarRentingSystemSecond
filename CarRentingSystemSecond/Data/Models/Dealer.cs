using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemSecond.Data.Models
{
    public class Dealer
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }
        public IEnumerable<Car> Cars { get; init; } = new List<Car>();
    }
}
