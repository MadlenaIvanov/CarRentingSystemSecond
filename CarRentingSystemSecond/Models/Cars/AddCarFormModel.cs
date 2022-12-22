using System.ComponentModel.DataAnnotations;
using static CarRentingSystemSecond.Data.DataConstraints;


namespace CarRentingSystemSecond.Models.Cars
{
    public class AddCarFormModel
    {
        [Required]
        [StringLength(CarBrandMaxLength, MinimumLength = CarBrandMinLength)]
        public string Brand { get; init; }

        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; init; }

        [Required]
        [StringLength(
            int.MaxValue, 
            MinimumLength = CarDescriptionMinLength,
            ErrorMessage = "The Description must be at least {2} symbols long.")]
        public string Description { get; init; }

        [Required]
        [Display(Name = "Image")]
        [Url]
        public string ImageUrl { get; init; }

        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<CarCategoryViewModel>? Categories { get; set; }
    }
}
