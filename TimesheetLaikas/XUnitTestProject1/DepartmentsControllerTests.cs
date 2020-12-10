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
    public class DepartmentsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        public DepartmentsControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private DepartmentsController CreateDepartmentsController()
        {
            return new DepartmentsController(
                this.mockApplicationDbContext.Object);
        }

        [Fact]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();
            string sortOrder = null;

            // Act
            var result = await departmentsController.Index(
                sortOrder);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();
            int? id = null;

            // Act
            var result = await departmentsController.Details(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();

            // Act
            var result = departmentsController.Create();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();
            Department department = null;

            // Act
            var result = await departmentsController.Create(
                department);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();
            int? id = null;

            // Act
            var result = await departmentsController.Edit(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();
            int id = 0;
            DepartmentViewModel department = null;

            // Act
            var result = await departmentsController.Edit(
                id,
                department);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();
            int? id = null;

            // Act
            var result = await departmentsController.Delete(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var departmentsController = this.CreateDepartmentsController();
            int id = 0;

            // Act
            var result = await departmentsController.DeleteConfirmed(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
