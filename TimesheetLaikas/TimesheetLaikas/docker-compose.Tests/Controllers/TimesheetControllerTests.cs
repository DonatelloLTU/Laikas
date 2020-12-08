using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Telerik.JustMock;
using TimesheetLaikas.Controllers;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using Xunit;

namespace .Controllers
{
    public class TimesheetControllerTests
    {
        private ApplicationDbContext mockApplicationDbContext;
        private UserManager<Employee> mockUserManager;
        private RoleManager<Roles> mockRoleManager;

        public TimesheetControllerTests()
        {
            this.mockApplicationDbContext = Mock.Create<ApplicationDbContext>();
            this.mockUserManager = Mock.Create<UserManager<Employee>>();
            this.mockRoleManager = Mock.Create<RoleManager<Roles>>();
        }

        private TimesheetController CreateTimesheetController()
        {
            return new TimesheetController(
                this.mockApplicationDbContext,
                this.mockUserManager,
                this.mockRoleManager);
        }

        [Fact]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            string sortOrder = null;

            // Act
            var result = await timesheetController.Index(
                sortOrder);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ViewTimesheets_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();

            // Act
            var result = await timesheetController.ViewTimesheets();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            int? id = null;

            // Act
            var result = await timesheetController.Details(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void TimePunch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();

            // Act
            var result = timesheetController.TimePunch();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task PunchIn_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            TimesheetViewModel model = null;

            // Act
            var result = await timesheetController.PunchIn(
                model);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task PunchOut_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            Timesheet timesheet = null;

            // Act
            var result = await timesheetController.PunchOut(
                timesheet);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();

            // Act
            var result = timesheetController.Create();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            TimesheetViewModel model = null;

            // Act
            var result = await timesheetController.Create(
                model);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            int? id = null;

            // Act
            var result = await timesheetController.Edit(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            int id = 0;
            TimesheetViewModel timesheet = null;

            // Act
            var result = await timesheetController.Edit(
                id,
                timesheet);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            int? id = null;

            // Act
            var result = await timesheetController.Delete(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var timesheetController = this.CreateTimesheetController();
            int id = 0;

            // Act
            var result = await timesheetController.DeleteConfirmed(
                id);

            // Assert
            Assert.True(false);
        }
    }
}
