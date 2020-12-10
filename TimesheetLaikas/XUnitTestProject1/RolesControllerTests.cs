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
    public class RolesControllerTests
    {
        private MockRepository mockRepository;

        private Mock<RoleManager<Roles>> mockRoleManager;
        private Mock<UserManager<Employee>> mockUserManager;
        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public RolesControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockRoleManager = this.mockRepository.Create<RoleManager<Roles>>();
            this.mockUserManager = this.mockRepository.Create<UserManager<Employee>>();
            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private RolesController CreateRolesController()
        {
            return new RolesController(
                this.mockRoleManager.Object,
                this.mockUserManager.Object,
                this.mockApplicationDbContext.Object);
        }

        [Fact]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rolesController = this.CreateRolesController();

            // Act
            var result = await rolesController.Index();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetEmployees_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rolesController = this.CreateRolesController();
            string? id = null;

            // Act
            var result = await rolesController.GetEmployees(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rolesController = this.CreateRolesController();

            // Act
            var result = rolesController.Create();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var rolesController = this.CreateRolesController();
            string id = null;
            RoleViewModel model = null;

            // Act
            var result = await rolesController.Create(
                id,
                model);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rolesController = this.CreateRolesController();
            string id = null;

            // Act
            var result = await rolesController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var rolesController = this.CreateRolesController();
            string id = null;
            RoleViewModel roles = null;

            // Act
            var result = await rolesController.Edit(
                id,
                roles);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rolesController = this.CreateRolesController();
            string id = null;

            // Act
            var result = await rolesController.Delete(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rolesController = this.CreateRolesController();
            string id = null;

            // Act
            var result = await rolesController.DeleteConfirmed(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
