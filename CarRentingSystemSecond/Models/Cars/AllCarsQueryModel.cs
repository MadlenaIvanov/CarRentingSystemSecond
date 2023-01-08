namespace CarRentingSystemSecond.Models.Cars
{
    public class AllCarsQueryModel
    {
        public IEnumerable<string> Brands { get; init; }
        public IEnumerable<string> SearchTerm { get; init; }

        public CarSorting Sorting { get; init; }
        public IEnumerable<CarListingViewModel> Cars { get; init; }
    }
}
