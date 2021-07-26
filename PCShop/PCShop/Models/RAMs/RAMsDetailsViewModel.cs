using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.RAMs
{
    public class RAMsDetailsViewModel
    {
        public string ImagePath { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int? Capacity { get; set; }

        public int? NumberOfSticks { get; set; }

        public string Timings { get; set; }

        public double Price { get; set; }

        public int? MinSpeed { get; set; }

        public int? ReleasedYear { get; set; }
    }
}
