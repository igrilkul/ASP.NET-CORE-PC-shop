using Microsoft.AspNetCore.Mvc;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.CPUCoolers;
using PCShop.Models.CPUs;
using PCShop.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PCShop.Test.Controller
{
    public class CPUsControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var cpusController = new CPUsController(data);
            var queryModel = Mock.Of<AllCPUsQueryModel>();

            //Act
            var result = cpusController.All(queryModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var cpusController = new CPUsController(data);
            var id = "1";
            var badId = "2";

            //Act
            var resultFound = cpusController.Details(id);
            RedirectToActionResult resultNotFound = (RedirectToActionResult)cpusController.Details(badId);

            //Assert
            Assert.NotNull(resultFound);
            Assert.IsType<ViewResult>(resultFound);

            Assert.NotNull(resultNotFound);
            Assert.Equal("Home", resultNotFound.ControllerName);
            Assert.Equal("Error", resultNotFound.ActionName);
        }

        public PCShopDbContext GetData()
        {
            var data = DatabaseMock.Instance;

            data.Products.Add(new Product
            {
                ImagePath = "https://p1.akcdn.net/full/592283181.amd-ryzen-5-3600-hexa-core-3-6ghz-am4.jpg",
                Platform = "AMD",
                Model = "Ryzen 5 3600",
                MinSpeed = 3600,
                MaxSpeed = 4200,
                TDP = 60,
                Price = 175.00,
                ReleasedYear = 2020,
                CategoryId = 2
            });
            data.SaveChanges();

            return data;
        }
    }
}
