using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Orders
{
    public class OrderInputViewModel
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }

        public string Province { get; set; }
        [Required]
        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
