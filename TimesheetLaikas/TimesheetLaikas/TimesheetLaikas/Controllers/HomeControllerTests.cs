using Microsoft.Extensions.Logging;
using System;
using Telerik.JustMock;
using TimesheetLaikas.Controllers;
using Xunit;

namespace TimesheetLaikas.Controllers
{
    public class HomeControllerTests
    {
        private ILogger<HomeController> mockLogger;

        public HomeControllerTests()
        {
            this.mockLogger = Mock.Create<ILogger<HomeController>>();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                this.mockLogger);
        }

        [Fact]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Privacy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Privacy();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Error_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Error();

            // Assert
            Assert.True(false);
        }
    }
}
