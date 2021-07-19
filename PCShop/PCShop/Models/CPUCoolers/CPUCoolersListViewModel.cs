using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.CPUCoolers
{
    public class CPUCoolersListViewModel
    {
        public int Id { get; init; }

        public string ImagePath { get; init; }

        public string Make { get; init; }

        public string Model { get; init; }

        public double Price { get; init; }
    }
}
