using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Orders
{
    public class OrdersListViewModel
    {
        public int OrderId { get; init; }

        public DateTime CreatedAt { get; init; }

        public string Recipient { get; init; }

        public double GrandTotal { get; init; }

        public string Status { get; init; }
    }
}
