using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCShop.Data;
using PCShop.Data.Models;
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
        public IActionResult Order(OrderInputViewModel details)
        {
            string currentUserID = GetUserId();

            var cart = this.data.Carts.Where(c => c.UserId == currentUserID).FirstOrDefault();
            var cartItems = this.data.CartItems.Where(c => c.CartId == cart.Id).ToList();

            if (!cartItems.Any())
            {
                return BadRequest();
            }

            if (details == null)
            {
                details = new OrderInputViewModel { };
            }

            return View(details);
        }

       

        [HttpPost]
        [Authorize]
        public IActionResult Order(OrderInputViewModel details,string decoy)
        {
            
            /*if (!ModelState.IsValid)
            {
                return View(details);
            }*/

            var detailsModel = new OrderInputViewModel
            {
                FirstName = details.FirstName,
                LastName = details.LastName,
                Mobile = details.Mobile,
                Email = details.Email,
                Address1 = details.Address1,
                Address2 = details.Address2,
                City = details.City,
                Province = details.Province,
                Country = details.Country,
                PostalCode = details.PostalCode
            };

            return RedirectToAction("Review", detailsModel);
        }

        [Authorize]
        public IActionResult Review(OrderInputViewModel detailsModel)
        {
            var currentUserID = GetUserId();

            var cartQuery = this.data
                .Carts
                .Where(c => c.UserId == currentUserID)
                .AsQueryable();

            if (cartQuery == null)
            {
                return BadRequest();
            }

            var itemsQuery = this.data
                .CartItems
                .Where(c => c.CartId == cartQuery.FirstOrDefault().Id)
                .AsQueryable();

            if(itemsQuery == null)
            {
                return BadRequest();
            }

            var itemsIds = itemsQuery.Select(c => c.ProductId).ToList();

            var productsQuery = this.data.Products.Where(c=> itemsIds.Contains(c.Id)).AsQueryable();

            var products = from c in cartQuery
                           join ci in itemsQuery on c.Id equals ci.CartId
                           join p in productsQuery on ci.ProductId equals p.Id
                           where c.UserId == currentUserID
                           select new
                           {
                               Id = p.Id,
                               Platform = p.Platform,
                               ImagePath = p.ImagePath,
                               Make = p.Make,
                               Model = p.Model,
                               Price = p.Price,
                               Quantity = ci.Quantity,
                               Discount = p.Discount,
                           };

            var productsList = products.ToList();

            var orderItemsViewModel = productsList.Select(c => new OrderItemViewModel
            {
                ImagePath = c.ImagePath,
                ProductId = c.Id,
                Price = c.Quantity * (c.Price - (c.Discount / 100) * c.Price),
                Make = c.Make,
                Model = c.Model,
                Platform = c.Platform,
                Quantity = c.Quantity
            }).ToList();

            var grandTotalPrice = orderItemsViewModel.Sum(c => c.Price);

            //ToDo: OrderId, CreatedOn
            var orderItemsPostModel = productsList.Select(c => new OrderItemPostModel
            {
                ProductId = c.Id,
                Discount = c.Discount,
                Quantity = c.Quantity,
                Price = c.Price,
            }).ToList();

            var discount = 0;

            var orderPostModel = new OrderPostModel
            {
                UserId = currentUserID,
                Status = "Created",
                BaseTotal = grandTotalPrice,
                Discount = discount,
                GrandTotal = grandTotalPrice - (grandTotalPrice * (discount / 100)),
                FirstName = detailsModel.FirstName,
                LastName = detailsModel.LastName,
                Mobile = detailsModel.Mobile,
                Email = detailsModel.Email,
                Address1 = detailsModel.Address1,
                Address2 = detailsModel.Address2,
                City = detailsModel.City,
                Province = detailsModel.Province,
                Country = detailsModel.Country,
                PostalCode = detailsModel.PostalCode,
            };


            var orderSummaryPostModel = new OrderSummaryPostModel
            {
                OrderPostModel = orderPostModel,
                OrderItemsPostModel = orderItemsPostModel
            };

            //Save order post model in temp data
            var orderString = Newtonsoft.Json.JsonConvert.SerializeObject(orderSummaryPostModel);
            TempData["orderPostTemp"] = orderString;


            var orderSummary = new OrderSummaryViewModel
            {
                GrandTotal = grandTotalPrice,
                Details = detailsModel,
                OrderItems = orderItemsViewModel
            };

            return View(orderSummary);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Review()
        {
            var currentUserID = GetUserId();
            var cartId = this.data.Carts.Where(c => c.UserId == currentUserID).Select(c=>c.Id).FirstOrDefault();

            var cartItems = this.data.CartItems.Where(c => c.CartId == cartId).ToList();
            this.data.CartItems.RemoveRange(cartItems);

            //Get saved order post model from temp data
            var orderString = TempData["orderPostTemp"] as string;
            var orderSummaryModel = Newtonsoft.Json.JsonConvert.DeserializeObject<OrderSummaryPostModel>(orderString);

            var orderModel = orderSummaryModel.OrderPostModel;
            var orderItemsModel = orderSummaryModel.OrderItemsPostModel;

            var order = new Order
            {
                UserId = orderModel.UserId,
                Status = orderModel.Status,
                BaseTotal = orderModel.BaseTotal,
                Discount = orderModel.Discount,
                GrandTotal = orderModel.GrandTotal,
                FirstName = orderModel.FirstName,
                LastName = orderModel.LastName,
                Mobile = orderModel.Mobile,
                Email = orderModel.Email,
                Address1 = orderModel.Address1,
                Address2 = orderModel.Address2,
                City = orderModel.City,
                Province = orderModel.Province,
                Country = orderModel.Country,
                PostalCode = orderModel.PostalCode,
                CreatedAt = DateTime.UtcNow
            };

            this.data.Orders.Add(order);
            this.data.SaveChanges();

            int orderId = order.Id;

            var itemsList = new List<Order_item>();

            foreach (var i in orderItemsModel)
            {
                var item = new Order_item
                {
                    OrderId = orderId,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Price,
                    Discount = i.Discount,
                    CreatedOn = DateTime.UtcNow
                };

                itemsList.Add(item);
            }

            this.data.Orderitems.AddRange(itemsList);

            this.data.SaveChanges();

            return View("OrderPlaced");
        }


        private string GetUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return currentUserID;
        }
    }
}
