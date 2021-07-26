using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.GPUs
{
    public class AllGPUsQueryModel
    {
        public const int ItemsPerPage = 1;

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

        public GPUSorting Sorting { get; init; }

        public IEnumerable<ProductListViewModel> GPUs { get; set; }
    }
}
