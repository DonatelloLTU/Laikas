using Microsoft.Extensions.Logging;
using Moq;
using System;
using TimesheetLaikas.Controllers;
using Xunit;

namespace TimesheetLaikas.Controllers
{
    public class HomeControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<HomeController>> mockLogger;

        public HomeControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<HomeController>>();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                this.mockLogger.Object);
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
            this.mockRepository.VerifyAll();
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
            this.mockRepository.VerifyAll();
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
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Index_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            object model = null;

            // Act
            var result = homeController.Index(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
