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
    public class RolesControllerTests
    {
        private RoleManager<Roles> mockRoleManager;
        private UserManager<Employee> mockUserManager;
        private ApplicationDbContext mockApplicationDbContext;

        public RolesControllerTests()
        {
            this.mockRoleManager = Mock.Create<RoleManager<Roles>>();
            this.mockUserManager = Mock.Create<UserManager<Employee>>();
            this.mockApplicationDbContext = Mock.Create<ApplicationDbContext>();
        }

        private RolesController CreateRolesController()
        {
            return new RolesController(
                this.mockRoleManager,
                this.mockUserManager,
                this.mockApplicationDbContext);
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
        }
    }
}
