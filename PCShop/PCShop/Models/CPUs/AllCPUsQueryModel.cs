using PCShop.Models.CPUs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.CPUs
{
    public class AllCPUsQueryModel
    {
        public const int CPUsPerPage = Constants.itemsPerPage;

        public int CurrentPage { get; init; } = 1;

        public int TotalCPUs { get; set; }

        public string Platform { get; init; }
        public IEnumerable<string> Platforms { get; set; }

        public IEnumerable<string> Model { get; set; }

        [Display(Name="Search")]
        public string SearchTerm { get; init; }

        public CPUSorting Sorting { get; init; }

        public IEnumerable<ProductListViewModel> CPUs { get; set; }
    }
}
