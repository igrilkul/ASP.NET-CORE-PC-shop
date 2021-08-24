using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models;
using PCShop.Test.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace PCShop.Test.Controller
{
    public class CartsControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var cartsController = new CartsController(data);
            ControllerContext context = GetContext();
            cartsController.ControllerContext = context;

            //Act
            var result = cartsController.All();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AddToCartShouldCreateCartAndCartItemAndRedirectToController()
        {
            //Arrange
            var data = GetData();
            var cartsController = new CartsController(data);
            ControllerContext context = GetContext();
            cartsController.ControllerContext = context;

            //Act
            RedirectToActionResult result = (RedirectToActionResult)cartsController.AddToCart("RAMs", "1");

            //Assert
            Assert.NotNull(result);
            Assert.True(data.Carts.Any());
            Assert.True(data.CartItems.Any());

            Assert.Equal("RAMs", result.ControllerName);
            Assert.Equal("All", result.ActionName);
        }

        [Fact]
        public void RemoveShouldRemoveFromCart()
        {
            //Arrange
            var data = GetData();
            var cartsController = new CartsController(data);
            ControllerContext context = GetContext();
            cartsController.ControllerContext = context;

            //Act
            cartsController.AddToCart("RAM", "1");
            RedirectToActionResult noItemResult = (RedirectToActionResult)cartsController.Remove("2");
            var successResult = cartsController.Remove("1");

            //Assert
            Assert.NotNull(successResult);
            Assert.NotNull(noItemResult);

            Assert.Equal("Home", noItemResult.ControllerName);
            Assert.Equal("Error", noItemResult.ActionName);

            Assert.True(data.Carts.Any());
            Assert.True(data.CartItems.Count()==0);
        }

        [Fact]
        public void AllPostShouldRedirectToOrder()
        {
            //Arrange
            var data = GetData();
            var cartsController = new CartsController(data);
            ControllerContext context = GetContext();
            cartsController.ControllerContext = context;

            //Act
            cartsController.AddToCart("RAM", "1");
            var models = new List<ProductListViewModel>();

            models.Add(new ProductListViewModel{
                Id=1,
                Quantity=1
            });

            RedirectToActionResult result = (RedirectToActionResult)cartsController.All(models);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Order", result.ActionName);
            Assert.Equal("Orders",result.ControllerName);
        }



        private static ControllerContext GetContext()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                        {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("custom-claim", "example claim value"),
                        }, "mock"));

            var context = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = user
                }
            };
            return context;
        }

        public PCShopDbContext GetData()
        {
            var data = DatabaseMock.Instance;

            data.Products.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/545789382.corsair-vengeance-rgb-pro-16gb-2x8gb-ddr4-3200mhz-cmw16gx4m2c3200c16.jpg",
                Make = "Corsair",
                Model = "VENGEANCE RGB Pro",
                Capacity = 16,
                NumberOfSticks = 2,
                Timings = "16-18-18-36",
                Price = 110,
                MinSpeed = 3200,
                ReleasedYear = 2018,
                CategoryId = 7
            });
            data.SaveChanges();

            return data;
        }
    }
}
