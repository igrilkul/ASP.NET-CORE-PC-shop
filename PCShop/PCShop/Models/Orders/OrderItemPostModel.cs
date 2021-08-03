using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Orders
{
    public class OrderItemPostModel
    {
        public int ProductId { get; init; }
        public int OrderId { get; init; }
        public double Discount { get; init; }
        public int Quantity { get; init; }
        public double Price { get; init; }
        public DateTime CreatedOn { get; init; }
    }
}
