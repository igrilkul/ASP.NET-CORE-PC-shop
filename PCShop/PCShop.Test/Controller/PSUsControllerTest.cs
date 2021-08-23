using Microsoft.AspNetCore.Mvc;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.PSUs;
using PCShop.Test.Mocks;
using System.Linq;
using Xunit;

namespace PCShop.Test.Controller
{
    public class PSUsControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var psusController = new PSUsController(data);
            var queryModel = Mock.Of<AllPSUsQueryModel>();

            //Act
            var result = psusController.All(queryModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var psusController = new PSUsController(data);
            var id = "1";
            var badId = "2";

            //Act
            var resultFound = psusController.Details(id);
            var resultNotFound = psusController.Details(badId);

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
                ImagePath = "https://p1.akcdn.net/full/493165149.corsair-rmx-series-rm850x-2018-850w-gold-cp-9020180.jpg",
                Make = "Corsair",
                Model = "RM850x",
                Power = 850,
                Efficiency = "80+ Gold",
                Price = 150,
                ReleasedYear = 2020,
                CategoryId = 6
            });
            data.SaveChanges();

            return data;
        }
    }
}
