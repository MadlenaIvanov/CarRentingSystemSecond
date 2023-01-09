﻿using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemSecond.Data.Models
{
    public class Dealer
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string Age { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
