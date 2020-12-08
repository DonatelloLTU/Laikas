using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using Xunit;

namespace XUnitTestProject1
{
    [Collection("SQLite")]
    public class ApplicationDbContextTest
    {
        private DBFixture _fixture;

        public ApplicationDbContextTest(DBFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task DataStorageSuccessfulFromSeedDataTestAsync()
        {

            Assert.True(await _fixture.Context.Employee.CountAsync().ConfigureAwait(false) == 0, "No data should exist yet for employees");
            Assert.True(await _fixture.Context.Timesheet.CountAsync().ConfigureAwait(false) == 0, "No data should exist yet for timesheets");


            TestData();

            Assert.True(await _fixture.Context.Employee.CountAsync().ConfigureAwait(false) == 3, "Missing employees from seeding data");
            Assert.True(await _fixture.Context.Timesheet.CountAsync().ConfigureAwait(false) == 5, "Missing timesheets from seeding data");

        }
        private void TestData()
        {

            SeedData.Initialize(_fixture.Context, new UserManager<Employee>(new UserStore<Employee>(_fixture.Context), null, null, null, null, null, null, null, null), new RoleManager<Employee>((IRoleStore<Employee>)_fixture.Context, null, null, null, null));
        }
    }
}
