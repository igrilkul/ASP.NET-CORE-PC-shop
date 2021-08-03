using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Orders
{
    public class OrderItemViewModel
    {
        public string ImagePath { get; init; }
        public int ProductId { get; init; }
        public double Price { get; init; }
        public float Discount { get; init; }
        public string Make { get; init; }
        public string Model { get; init; }
        public string Platform { get; init; }
        public int Quantity { get; init; }
    }
}
