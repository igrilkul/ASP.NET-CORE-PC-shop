
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.CPUCoolers
{
    public class CPUCoolersDetailsViewModel
    {
        public string ImagePath { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
        
        public double? Price { get; set; }

        public double? Airflow { get; set; }

        public int? RPM { get; set; }

        public double? Noise { get; set; }

        public string Dimensions { get; set; }

        public int? ReleasedYear { get; set; }
    }
}
