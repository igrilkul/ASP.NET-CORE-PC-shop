using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PCShopDbContext data;

        public OrdersController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Order()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cart = this.data.Carts.Where(c => c.UserId == currentUserID).FirstOrDefault();
            var cartItems = this.data.CartItems.Where(c => c.CartId == cart.Id).ToList();

            if (!cartItems.Any())
            {
                return BadRequest();
            }

            return View(new OrderInputViewModel
            {
                
            });
        }
    }
}
