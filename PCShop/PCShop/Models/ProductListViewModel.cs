using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models
{
    public class ProductListViewModel
    {
        public int Id { get; init; }

        public string ImagePath { get; init; }

        public string Platform { get; init; }

        public string Make { get; init; }

        public string Model { get; init; }

        public double Price { get; init; }

        public string Size { get; init; }

        public int? MinSpeed { get; init; }

        public int? Capacity { get; init; }

        public int? ReleasedYear { get; init; }

        public int? Power { get; init; }

        public string Efficiency { get; init; }
    }
}
