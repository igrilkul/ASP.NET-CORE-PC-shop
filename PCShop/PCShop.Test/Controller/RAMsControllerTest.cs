

using Microsoft.AspNetCore.Mvc;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.RAMs;
using PCShop.Test.Mocks;
using Xunit;

namespace PCShop.Test.Controller
{
    public class RAMsControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var ramsController = new RAMsController(data);
            var queryModel = Mock.Of<AllRAMsQueryModel>();

            //Act
            var result = ramsController.All(queryModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var ramsController = new RAMsController(data);
            var id = "1";
            var badId = "2";

            //Act
            var resultFound = ramsController.Details(id);
            var resultNotFound = ramsController.Details(badId);

            //Assert
            Assert.NotNull(resultFound);
            Assert.IsType<ViewResult>(resultFound);

            Assert.NotNull(resultNotFound);
            Assert.IsType<BadRequestResult>(resultNotFound);
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
