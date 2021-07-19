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
        public const int CPUsPerPage = 1;

        public int CurrentPage { get; init; }
        public string Platform { get; init; }
        public IEnumerable<string> Platforms { get; init; }

        public IEnumerable<string> Model { get; init; }

        [Display(Name="Search")]
        public string SearchTerm { get; init; }

        public CPUSorting Sorting { get; init; }

        public IEnumerable<CPUsListViewModel> CPUs { get; init; }
    }
}
