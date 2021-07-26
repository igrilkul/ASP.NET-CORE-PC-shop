using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.GPUs
{
    public class GPUsDetailsViewModel
    {
        public string ImagePath { get; set; }

        public string Platform { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public int? MinSpeed { get; set; }

        public int? NumberOfFans { get; set; }

        public int? ReleasedYear { get; set; }
    }
}
