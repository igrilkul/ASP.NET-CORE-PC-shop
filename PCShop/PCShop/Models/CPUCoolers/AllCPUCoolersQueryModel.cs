using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.CPUCoolers
{
    public class AllCPUCoolersQueryModel
    {
        public const int ItemsPerPage = 1;

        public int CurrentPage { get; init; } = 1;

        public int TotalCPUCoolers { get; set; }

        public string Make { get; init; }

        public IEnumerable<string> Makes { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public CPUCoolerSorting Sorting { get; init; }

        public IEnumerable<ProductListViewModel> CPUCoolers { get; set; }
    }
}
