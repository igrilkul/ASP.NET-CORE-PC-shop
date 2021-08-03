using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Orders
{
    public class OrderSummaryViewModel
    {
        public OrderInputViewModel Details { get; init; }

        public double GrandTotal { get; init; }
        public ICollection<OrderItemViewModel> OrderItems { get; init; }
    }
}
