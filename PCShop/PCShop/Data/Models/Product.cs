using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Data.Models
{
    public class Product
    {
        public int Id { get; init; }

        public int CategoryId { get; set; }
        public Category Category { get; init; }

        public string ImagePath { get; set; }

        public string Platform { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        [Required]
        public double Price { get; set; }

        public int? ReleasedYear { get; set; }

        //Case, Motherboard, RAM
        public string Size { get; set; }
        //CPU, GPU, RAM
        public int? MinSpeed { get; set; }
        //CPU
        public int? MaxSpeed { get; set; }

        //CPU, GPU
        public int? TDP { get; set; }
        //GPU, CPU Cooler
        public int? NumberOfFans { get; set; }
        //CPU Cooler
        public double? Airflow { get; set; }
        //CPU Cooler
        public int? RPM { get; set; }
        //CPU Cooler
        public double? Noise { get; set; }
        //CPU Cooler
        public string Dimensions { get; set; }
        //PSU
        public int? Power { get; set; }
        //PSU
        public string Efficiency { get; set; }
        //RAM
        public int? NumberOfSticks { get; set; }
        //RAM
        public string Timings { get; set; }

        public int? Capacity { get; set; }

    }
}
