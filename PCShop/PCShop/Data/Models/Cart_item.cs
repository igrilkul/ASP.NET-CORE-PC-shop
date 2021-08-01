using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCShop.Data.Models
{
    public class Cart_item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order=0)]
        public int Id { get; init; }

        [Key, Column(Order=1)]
        public int CartId { get; init; }
        public Cart Cart { get; init; }

        public int ProductId { get; init; }
        public Product Product { get; init; }

        public int Quantity { get; set; }
    }
}
