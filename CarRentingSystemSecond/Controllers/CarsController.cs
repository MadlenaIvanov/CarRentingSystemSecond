﻿using CarRentingSystemSecond.Data;
using CarRentingSystemSecond.Data.Models;
using CarRentingSystemSecond.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystemSecond.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRentingDbContext data;

        public CarsController(CarRentingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View(new AddCarFormModel
        {
            Categories = this.GetCarCategories()
        });

        public IActionResult All(string searchTerm)
        {
            var carsQuery = this.data.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery.Where(c =>
                    c.Brand.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Model.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }


            var cars = carsQuery
                .OrderByDescending(c => c.Id)
                .Select(c => new CarListingViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl,
                    Category = c.Category.Name
                })
                .ToList();

            return View(new AllCarsQueryModel
            {
                Cars = cars,
                SearchTerm = searchTerm
            });  
        }

        [HttpPost]
        public IActionResult Add(AddCarFormModel car)
        {
            if (!this.data.Categories.Any(c => c.Id == car.CategoryId))
            {
                this.ModelState.AddModelError(nameof(car.CategoryId), "Category doesn't exist.");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = this.GetCarCategories();

                return View(car);
            }

            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryId
            };

            this.data.Cars.Add(carData);

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<CarCategoryViewModel> GetCarCategories()
            => this.data
                .Categories
                .Select(c => new CarCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
    }
}
