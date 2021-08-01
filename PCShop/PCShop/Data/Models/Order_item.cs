using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCShop.Data.Models
{
    public class Order_item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; init; }

        [Key, Column(Order = 1)]
        public int ProductId { get; init; }
        public Product Product { get; init; }

        public int OrderId { get; init; }
        public Order Order { get; init; }
        
        public float Price { get; init; }

        public float Discount { get; init; }

        public int Quantity { get; init; }

        public DateTime CreatedOn { get; init; }
    }
}
