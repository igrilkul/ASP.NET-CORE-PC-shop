using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShop.Data.Models
{
    public class Cart
    {
        public int Id { get; init; }

        public string UserId { get; init; }
        public User User { get; init; }
        
        public IEnumerable<Cart_item> Items { get; init; } = new List<Cart_item>();
    }
}
