using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PCShop.Controllers
{
    public class CartsController : Controller
    {
        private readonly PCShopDbContext data;

        public CartsController(
            PCShopDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult All()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cartQuery = this.data.Carts.Where(c => c.UserId == currentUserID).AsQueryable();
            var cart = this.data.Carts.Where(c => c.UserId == currentUserID).FirstOrDefault();
            if (cart == null)
            {
                this.data.Carts.Add(new Cart
                {
                    UserId = currentUserID
                });

                this.data.SaveChanges();

                cart = this.data.Carts.Where(c => c.UserId == currentUserID).FirstOrDefault();
            }

            var itemsQuery = this.data.CartItems.Where(c => c.CartId == cart.Id).AsQueryable();

            var itemsIds = itemsQuery.Select(c => c.ProductId).ToList();
            
            var productsQuery = this.data.Products.Where(c => itemsIds.Contains(c.Id)).AsQueryable();

            var productsList = from c in cartQuery
                       join ci in itemsQuery on c.Id equals ci.CartId
                       join p in productsQuery on ci.ProductId equals p.Id
                       where c.UserId == currentUserID
                       select new ProductListViewModel
                       {
                           Id = p.Id,
                           Platform = p.Platform,
                           Size = p.Size,
                           MinSpeed = p.MinSpeed,
                           Capacity = p.Capacity,
                           ReleasedYear = p.ReleasedYear,
                           CategoryId = p.CategoryId,
                           ImagePath = p.ImagePath,
                           Make = p.Make,
                           Model = p.Model,
                           Price = p.Price,
                           Power = p.Power,
                           Efficiency = p.Efficiency,
                           Quantity = ci.Quantity
                       };

            return View(productsList.ToList());

        }

        [Authorize]
        public IActionResult AddToCart(string controllerType, string id)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cart = this.data.Carts.Where(c => c.UserId == currentUserID).FirstOrDefault();

            if (cart == null)
            {
                this.data.Carts.Add(new Cart
                {
                    UserId = currentUserID
                });

                this.data.SaveChanges();

                cart = this.data.Carts.Where(c => c.UserId == currentUserID).FirstOrDefault();
            }

            var item = this.data.CartItems.Where(i => i.ProductId == Int32.Parse(id) && i.CartId == cart.Id).FirstOrDefault();

            if (item == null)
            {
                this.data.CartItems.Add(new Cart_item
                {
                    CartId = cart.Id,
                    ProductId = Int32.Parse(id),
                    Quantity = 1
                });

                this.data.SaveChanges();

                item = this.data.CartItems.Where(i => i.ProductId == Int32.Parse(id) && i.CartId == cart.Id).FirstOrDefault();
            }
            else
            {
                item.Quantity++;

                this.data.SaveChanges();
            }

            return RedirectToAction("All", controllerType);
        }

        [Authorize]
        public IActionResult Remove(string id)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cart = this.data.Carts.Where(c => c.UserId == currentUserID).FirstOrDefault();

            if(cart == null)
            {
                return BadRequest();
            }

            var item = this.data.CartItems.Where(c => c.ProductId == Int32.Parse(id) && c.CartId == cart.Id).FirstOrDefault();
            if(item == null)
            {
                return BadRequest();
            }

            this.data.CartItems.Remove(item);
            this.data.SaveChanges();

            return RedirectToAction("All","Carts");
        }
    }
}
