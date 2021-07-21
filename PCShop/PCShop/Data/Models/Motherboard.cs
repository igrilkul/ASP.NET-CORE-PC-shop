﻿using System.ComponentModel.DataAnnotations;


namespace PCShop.Data.Models
{
    public class Motherboard
    {
        public int Id { get; init; }

        public string ImagePath { get; set; }

        [Required]
        [MaxLength(30)]
        public string Make { get; set; }

        public string Platform { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        public string Size { get; set; }

        [Required]
        public double Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
