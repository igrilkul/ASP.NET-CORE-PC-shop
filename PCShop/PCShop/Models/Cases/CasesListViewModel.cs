using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Cases
{
    public class CasesListViewModel
    {
        public int Id { get; init; }

        public string ImagePath { get; init; }

        public string Make { get; init; }

        public string Model { get; init; }

        public double Price { get; init; }

        public string Size { get; set; }

        public int ReleasedYear { get; set; }
    }
}
