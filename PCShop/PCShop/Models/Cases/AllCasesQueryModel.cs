using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCShop.Models.Cases
{
    public class AllCasesQueryModel
    {
        public const int CasesPerPage = Constants.itemsPerPage;

        public int CurrentPage { get; init; } = 1;

        public int TotalCases { get; set; }

        public string Make { get; init; }

        public IEnumerable<string> Makes { get; set; }

        public string Size { get; init; }
        public IEnumerable<string> Sizes { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public CaseSorting Sorting { get; init; }

        public IEnumerable<ProductListViewModel> Cases { get; set; }
    }
}

