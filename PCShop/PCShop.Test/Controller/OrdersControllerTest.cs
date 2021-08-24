using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.Orders;
using PCShop.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PCShop.Test.Controller
{
    public class OrdersControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var ordersController = new OrdersController(data);
            ControllerContext context = GetContext();
            ordersController.ControllerContext = context;

            //Act
            var result = ordersController.All();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void OrderShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var ordersController = new OrdersController(data);
            ControllerContext context = GetContext();
            ordersController.ControllerContext = context;
            var details = new OrderInputViewModel
            {
                Address1 = "Mladezhka 1"
            };

            //Act
            var result = ordersController.Order(details);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void OrderShouldRedirect()
        {
            //Arrange
            var data = GetData();
            var ordersController = new OrdersController(data);
            ControllerContext context = GetContext();
            ordersController.ControllerContext = context;
            var details = new OrderInputViewModel
            {
                Address1 = "Mladezhka 1"
            };

            //Act
            RedirectToActionResult result = (RedirectToActionResult)ordersController.Order(details,"");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Review", result.ActionName);
        }

        [Fact]
        public void ReviewShouldReturnView()
        {
            //Arrange
            var tempData = GetTempData();

            var data = GetData();
            var ordersController = new OrdersController(data)
            {
                TempData = tempData
            };

            ControllerContext context = GetContext();
            ordersController.ControllerContext = context;
            var details = new OrderInputViewModel
            {
                Address1 = "Mladezhka 1"
            };



            //Act
            var result = ordersController.Review(details);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ReviewPostShouldPostAndReturnView()
        {
            //Arrange
            var tempData = GetTempData();

            var data = GetData();
            var ordersController = new OrdersController(data)
            {
                TempData = tempData
            };

            ControllerContext context = GetContext();
            ordersController.ControllerContext = context;

            //Act
            var result = ordersController.Review();

            //Assert
            Assert.NotNull(result);
            Assert.True(data.Orderitems.Count() == 1);
            Assert.True(data.Orders.Count() == 1);
            Assert.IsType<ViewResult>(result);
        }

        private static TempDataDictionary GetTempData()
        {
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            var orderString = "{\"OrderPostModel\":{\"UserId\":\"1\",\"Status\":\"Created\",\"BaseTotal\":220.0,\"Discount\":0.0,\"GrandTotal\":220.0,\"FirstName\":\"Tester\",\"LastName\":\"Kegefg\",\"Mobile\":\"+359888888888\",\"Email\":\"asdasd@abv.bg\",\"Address1\":\"srwgwsfg 2\",\"Address2\":null,\"City\":\"Plodvidv\",\"Province\":\"Pldvoidv\",\"Country\":\"Bulgaria\",\"PostalCode\":\"4000\",\"CreatedAt\":\"0001-01-01T00:00:00\"},\"OrderItemsPostModel\":[{\"ProductId\":1,\"OrderId\":0,\"Discount\":0.0,\"Quantity\":2,\"Price\":110.0,\"CreatedOn\":\"0001-01-01T00:00:00\"}]}";
            tempData["orderPostTemp"] = orderString;
            return tempData;
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var tempData = GetTempData();

            var data = GetData();
            var ordersController = new OrdersController(data)
            {
                TempData = tempData
            };

            ControllerContext context = GetContext();
            ordersController.ControllerContext = context;

            //Act
            ordersController.Review();
            var result = ordersController.Details("1");
            RedirectToActionResult noIdResult = (RedirectToActionResult)ordersController.Details("2");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal("Home", noIdResult.ControllerName);
            Assert.Equal("Error", noIdResult.ActionName);
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

            data.Carts.Add(new Cart { Id = 1, UserId = "1" });
            data.CartItems.Add(new Cart_item { Id = 1, CartId = 1, ProductId = 1, Quantity = 2 });

            data.SaveChanges();

            return data;
        }
    }
}
