using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemSecond.Models.Cars
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 3;

        public string Brand { get; init; }

        public IEnumerable<string> Brands { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCars { get; set; }

        public CarSorting Sorting { get; init; }

        public IEnumerable<CarListingViewModel> Cars { get; set; }
    }
}
