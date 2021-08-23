using Microsoft.AspNetCore.Mvc;
using Moq;
using PCShop.Controllers;
using PCShop.Data;
using PCShop.Data.Models;
using PCShop.Models.Cases;
using PCShop.Test.Mocks;
using Xunit;

namespace PCShop.Test.Controller
{
    public class CasesControllerTest
    {
        [Fact]
        public void AllShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var casesController = new CasesController(data);
            var queryModel = Mock.Of<AllCasesQueryModel>();

            //Act
            var result = casesController.All(queryModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            //Arrange
            var data = GetData();
            var casesController = new CasesController(data);
            var id = "1";
            var badId = "2";

            //Act
            var resultFound = casesController.Details(id);
            var resultNotFound = casesController.Details(badId);

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
                ImagePath = "https://p1.akcdn.net/full/680782590.be-quiet-pure-base-500dx-bgw37-bgw38.jpg",
                Make = "Be Quiet!",
                Model = "Pure Base 500DX",
                Size = "ATX",
                Price = 110.00,
                ReleasedYear = 2018,
                CategoryId = 1
            });
            data.SaveChanges();

            return data;
        }
    }
}
