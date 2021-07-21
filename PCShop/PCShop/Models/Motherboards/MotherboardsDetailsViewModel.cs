using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Motherboards
{
    public class MotherboardsDetailsViewModel
    {
        public string ImagePath { get; set; }

       
        public string Make { get; set; }

        public string Platform { get; set; }
        
        public string Model { get; set; }

        public string Size { get; set; }

        
        public double Price { get; set; }

        public int ReleasedYear { get; set; }
    }
}
