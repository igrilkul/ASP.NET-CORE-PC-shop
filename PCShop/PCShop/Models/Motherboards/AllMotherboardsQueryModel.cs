using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Motherboards
{
    public class AllMotherboardsQueryModel
    {
        public const int ItemsPerPage = Constants.itemsPerPage;

        public int CurrentPage { get; init; } = 1;

        public int TotalCount { get; set; }

        public string Platform { get; init; }
        public IEnumerable<string> Platforms { get; set; }

        public string Make { get; init; }
        public IEnumerable<string> Makes { get; set; }

        public string Model { get; init; }
        public IEnumerable<string> Models { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public MotherboardSorting Sorting { get; init; }

        public IEnumerable<ProductListViewModel> Motherboards { get; set; }
    }
}
