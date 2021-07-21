using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.PSUs
{
    public class PSUsListViewModel
    {
        public int Id { get; init; }

        public string ImagePath { get; init; }

        public string Make { get; init; }

        public string Model { get; init; }

        public int Power { get; set; }

        public string Efficiency { get; set; }

        public double Price { get; init; }
    }
}
