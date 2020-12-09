using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XUnitTestProject1;
using Xunit;
using System.Threading.Tasks;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Web.Mvc;

namespace TimesheetLaikas.Controllers.Tests
{
    [Collection("SQLite")]
    public class TimesheetControllerTests
    {
        private DBFixture _fixture;
        private object EmpID;

        public TimesheetControllerTests(DBFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task DataStorageSuccessfulFromSeedDataTestAsync()
        {

            Assert.True(await _fixture.Context.Employee.CountAsync().ConfigureAwait(false) == 0, "No data should exist yet for employees");
            Assert.True(await _fixture.Context.Timesheet.CountAsync().ConfigureAwait(false) == 0, "No data should exist yet for timesheets");


            TestSeedData();

            Assert.True(await _fixture.Context.Employee.CountAsync().ConfigureAwait(false) == 3, "Missing employees from seeding data");
            Assert.True(await _fixture.Context.Timesheet.CountAsync().ConfigureAwait(false) == 5, "Missing timesheets from seeding data");

        }

        private void TestSeedData()
        {
            DBFixture seedData = new DBFixture();
            
        }
        [Fact]
        public void TestDetailsView()
        {
            var controller = new TimesheetController();
            var result = Controller.Details(1) as ViewResult;
            Assert.Equal("Details", result.ViewName);

        }

    }
}