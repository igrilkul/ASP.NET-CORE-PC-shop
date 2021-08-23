using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
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
    public class CartsControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var cartsController = new CartsController(data);

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

            // Then set it to controller before executing test
            cartsController.ControllerContext = context;

            //Act
            var result = cartsController.All();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        
        public PCShopDbContext GetData()
        {
            var data = DatabaseMock.Instance;

           
            //data.SaveChanges();

            return data;
        }
    }
}
