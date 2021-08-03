using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Models.Orders
{
    public class OrderSummaryPostModel
    {
        public OrderPostModel OrderPostModel { get; init; }

        public ICollection<OrderItemPostModel> OrderItemsPostModel { get; init; }
    }
}
