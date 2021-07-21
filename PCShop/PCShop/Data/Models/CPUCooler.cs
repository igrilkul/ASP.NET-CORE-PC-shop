﻿using System.ComponentModel.DataAnnotations;


namespace PCShop.Data.Models
{
    public class CPUCooler
    {
        public int Id { get; init; }

        public string ImagePath { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
        [Required]
        public double Price { get; set; }

        public double Airflow { get; set; }

        public int RPM { get; set; }

        public double Noise { get; set; }

        public string Dimensions { get; set; }

        public int ReleasedYear { get; set; }
    }
}
