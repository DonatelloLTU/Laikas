using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Data.Sqlite;
using TimesheetLaikas.Models;
using Xunit;

namespace XUnitTestProject
{
    [TestFixture]
    public class EmployeeProviderTest
    {
        [Test]
        public void Test_Get_By_Id()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<Employee>().UseSqlite(connection).Options;

            using (var context = new Employee(options))
            {
                context.Database.EnsureCreated();
            }

            using (var context = new EmployeeContext(options))
            {
                context.Employees.Add(new Employee { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Street", HomePhone = "111-111-1111", CellPhone = "222-222-2222" });
                context.SaveChanges();
            }

            using (var context = new EmployeeContext(options))
            {
                var provider = new EmployeeProvider(context);
                var employee = provider.Get(1);

                Assert.AreEqual("John", employee.FirstName);
            }
        }
    }
}