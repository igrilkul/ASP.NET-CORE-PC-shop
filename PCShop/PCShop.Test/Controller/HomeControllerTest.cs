using Microsoft.AspNetCore.Mvc;
using PCShop.Controllers;
using Xunit;

namespace PCShop.Test.Controller
{
    public class HomeControllerTest
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Error();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Index();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

    }
}
