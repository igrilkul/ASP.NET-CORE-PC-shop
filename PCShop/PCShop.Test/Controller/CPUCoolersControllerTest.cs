using Microsoft.AspNetCore.Mvc;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.CPUCoolers;
using PCShop.Test.Mocks;
using Xunit;

namespace PCShop.Test.Controller
{
    public class CPUCoolersControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var coolersController = new CPUCoolersController(data);
            var queryModel = Mock.Of<AllCPUCoolersQueryModel>();

            //Act
            var result = coolersController.All(queryModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var coolersController = new CPUCoolersController(data);
            var id = "1";
            var badId = "2";

            //Act
            var resultFound = coolersController.Details(id);
            RedirectToActionResult resultNotFound = (RedirectToActionResult)coolersController.Details(badId);

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
                ImagePath = "https://p1.akcdn.net/full/678025767.noctua-noctua-nh-u12s-fan-nh-u12s-ch.jpg",
                Make = "Noctua",
                Model = "NH-U12S Chromax",
                Price = 70,
                ReleasedYear = 2015,
                Airflow = 54.90,
                RPM = 1500,
                Noise = 22.4,
                Dimensions = "158 x 125 x 71",
                CategoryId = 3
            });
            data.SaveChanges();

            return data;
        }
    }
}
