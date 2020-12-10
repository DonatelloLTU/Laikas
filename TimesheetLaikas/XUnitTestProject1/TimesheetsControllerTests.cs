using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Threading.Tasks;
using TimesheetLaikas.Controllers;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using TimesheetLaikas.Models.ViewModels;
using Xunit;

namespace TimesheetLaikas.Controllers
{
    public class TimesheetsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;
        private Mock<UserManager<Employee>> mockUserManager;
        private Mock<RoleManager<Roles>> mockRoleManager;

        public TimesheetsControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
            this.mockUserManager = this.mockRepository.Create<UserManager<Employee>>();
            this.mockRoleManager = this.mockRepository.Create<RoleManager<Roles>>();
        }

        private TimesheetsController CreateTimesheetsController()
        {
            return new TimesheetsController(
                this.mockApplicationDbContext.Object,
                this.mockUserManager.Object,
                this.mockRoleManager.Object);
        }

        [Fact]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();

            // Act
            var result = await timesheetsController.Index();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ViewTimesheets_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();

            // Act
            var result = await timesheetsController.ViewTimesheets();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ViewDepartmentTimesheets_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();

            // Act
            var result = await timesheetsController.ViewDepartmentTimesheets();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            int? id = null;

            // Act
            var result = await timesheetsController.Details(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TimePunch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();

            // Act
            var result = timesheetsController.TimePunch();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task PunchIn_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            TimesheetViewModel model = null;

            // Act
            var result = await timesheetsController.PunchIn(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task PunchOut_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            Timesheet timesheet = null;

            // Act
            var result = await timesheetsController.PunchOut(
                timesheet);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();

            // Act
            var result = timesheetsController.Create();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            TimesheetViewModel model = null;

            // Act
            var result = await timesheetsController.Create(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            int? id = null;

            // Act
            var result = await timesheetsController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            int id = 0;
            TimesheetViewModel timesheet = null;

            // Act
            var result = await timesheetsController.Edit(
                id,
                timesheet);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            int? id = null;

            // Act
            var result = await timesheetsController.Delete(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetsController = this.CreateTimesheetsController();
            int id = 0;

            // Act
            var result = await timesheetsController.DeleteConfirmed(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
