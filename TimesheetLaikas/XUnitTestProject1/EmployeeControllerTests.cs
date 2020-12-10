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
    public class EmployeeControllerTests
    {
        private MockRepository mockRepository;

        private Mock<UserManager<Employee>> mockUserManager;
        private Mock<RoleManager<Roles>> mockRoleManager;
        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public EmployeeControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUserManager = this.mockRepository.Create<UserManager<Employee>>();
            this.mockRoleManager = this.mockRepository.Create<RoleManager<Roles>>();
            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EmployeeController CreateEmployeeController()
        {
            return new EmployeeController(
                this.mockUserManager.Object,
                this.mockRoleManager.Object,
                this.mockApplicationDbContext.Object);
        }

        [Fact]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeController = this.CreateEmployeeController();
            string sortOrder = null;

            // Act
            var result = await employeeController.Index(
                sortOrder);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void AddUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeController = this.CreateEmployeeController();

            // Act
            var result = employeeController.AddUser();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task AddUser_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var employeeController = this.CreateEmployeeController();
            UserViewModel model = null;

            // Act
            var result = await employeeController.AddUser(
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeController = this.CreateEmployeeController();
            string id = null;

            // Act
            var result = await employeeController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var employeeController = this.CreateEmployeeController();
            string id = null;
            UserViewModel model = null;

            // Act
            var result = await employeeController.Edit(
                id,
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
