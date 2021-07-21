using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.PSUs
{
    public class PSUsDetailsViewModel
    {
        public string ImagePath { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Power { get; set; }

        public string Efficiency { get; set; }
        
        public double Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
