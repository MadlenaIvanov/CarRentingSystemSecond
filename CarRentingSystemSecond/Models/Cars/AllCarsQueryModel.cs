using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemSecond.Models.Cars
{
    public class AllCarsQueryModel
    {
        public string Brand { get; init; }
        public IEnumerable<string> Brands { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public CarSorting Sorting { get; init; }
        public IEnumerable<CarListingViewModel> Cars { get; set; }
    }
}
