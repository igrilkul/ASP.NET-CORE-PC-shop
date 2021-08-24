using Microsoft.AspNetCore.Mvc;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.Motherboards;
using PCShop.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PCShop.Test.Controller
{
    public class MotherboardsControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var motherboardsController = new MotherboardsController(data);
            var queryModel = Mock.Of<AllMotherboardsQueryModel>();

            //Act
            var result = motherboardsController.All(queryModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var motherboardsController = new MotherboardsController(data);
            var id = "1";
            var badId = "2";

            //Act
            var resultFound = motherboardsController.Details(id);
            RedirectToActionResult resultNotFound = (RedirectToActionResult)motherboardsController.Details(badId);

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
                ImagePath = "https://p1.akcdn.net/full/757175553.msi-b450-tomahawk-max-ii.jpg",
                Make = "MSI",
                Platform = "AMD",
                Model = "B450 Tomahawk Max",
                Price = 110,
                Size = "ATX",
                ReleasedYear = 2019,
                CategoryId = 5
            });
            data.SaveChanges();

            return data;
        }
    }
}
