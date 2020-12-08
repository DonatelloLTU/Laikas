using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    [CollectionDefinition("SQLite")]
    public class DBCollection : ICollectionFixture<DBFixture>
    {
      
    }
}
