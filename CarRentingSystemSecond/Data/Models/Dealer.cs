using System.ComponentModel.DataAnnotations;
using static CarRentingSystemSecond.Data.DataConstraints;

namespace CarRentingSystemSecond.Data.Models
{
    public class Dealer
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DealerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DealerPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Car> Cars { get; init; } = new List<Car>();
    }
}
