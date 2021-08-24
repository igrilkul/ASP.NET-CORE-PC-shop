using Microsoft.AspNetCore.Mvc;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.GPUs;
using PCShop.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PCShop.Test.Controller
{
    public class GPUsControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var gpusController = new GPUsController(data);
            var queryModel = Mock.Of<AllGPUsQueryModel>();

            //Act
            var result = gpusController.All(queryModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var gpusController = new GPUsController(data);
            var id = "1";
            var badId = "2";

            //Act
            var resultFound = gpusController.Details(id);
            RedirectToActionResult resultNotFound = (RedirectToActionResult)gpusController.Details(badId);

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
                ImagePath = "https://p1.akcdn.net/full/788241189.msi-geforce-rtx-3060-12gb-gddr6-192bit-rtx-3060-gaming-x-trio-12g.jpg",
                Platform = "Nvidia",
                Make = "MSI",
                Model = "RTX 3060",
                Price = 899,
                ReleasedYear = 2020,
                MaxSpeed = 1800,
                NumberOfFans = 3,
                CategoryId = 4
            });
            data.SaveChanges();

            return data;
        }
    }
}
