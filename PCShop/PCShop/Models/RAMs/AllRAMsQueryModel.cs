using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.RAMs
{
    public class AllRAMsQueryModel
    {
        public const int ItemsPerPage = 1;

        public int CurrentPage { get; init; } = 1;

        public int TotalCount { get; set; }

        public string Make { get; init; }
        public IEnumerable<string> Makes { get; set; }

        public int Speed { get; set; }
        public IEnumerable<int> Speeds { get; set; }

        public int Size { get; set; }
        public IEnumerable<int> Sizes { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public RAMSorting Sorting { get; init; }

        public IEnumerable<RAMsListViewModel> RAMs { get; set; }
    }
}
