using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.CPUs
{
    public class CPUDetailsViewModel
    {
        

        public string ImagePath { get; set; }

        public string Platform { get; set; }

        public string Model { get; set; }

        public int? MinSpeed { get; set; }

        public int? MaxSpeed { get; set; }


        public int? TDP { get; set; }
        
        public double Price { get; set; }

        public int? ReleasedYear { get; set; }
    }
}
