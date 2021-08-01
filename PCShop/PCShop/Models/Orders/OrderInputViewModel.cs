﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Orders
{
    public class OrderInputViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
