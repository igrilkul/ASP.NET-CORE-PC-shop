using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.PSUs
{
    public class AllPSUsQueryModel
    {
        public const int ItemsPerPage = 1;

        public int CurrentPage { get; init; } = 1;

        public int TotalCount { get; set; }

        public string Make { get; init; }
        public IEnumerable<string> Makes { get; set; }

        public string Efficiency { get; set; }
        public IEnumerable<string> Efficiencies { get; set; }

        public int Power { get; set; }
        public IEnumerable<int> Powers { get; set; }


        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public PSUSorting Sorting { get; init; }

        public IEnumerable<PSUsListViewModel> PSUs { get; set; }
    }
}
