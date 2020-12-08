using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimesheetLaikas.Data;

namespace XUnitTestProject1
{
    public class DBFixture : IDisposable
    {
        public ApplicationDbContext Context { get; }
        public DBFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("DataSource=file::memory:?cache=shared")
                .Options;

            Context = new ApplicationDbContext(options);

            Context.Database.OpenConnection();
            Context.Database.Migrate();
        }



        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Database.CloseConnection();
            Context.Dispose();
            
        
        }
    }
}
