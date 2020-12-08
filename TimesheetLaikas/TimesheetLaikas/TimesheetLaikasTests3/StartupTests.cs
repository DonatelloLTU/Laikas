using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimesheetLaikas;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;


namespace TimesheetLaikas.Tests
{
    [TestClass()]
    public class StartupTests
    {
        [Fact]
        public async Task StatusMiddlewareReturnsPong()
        {
            var hostBuilder = new WebHostBuilder().UseStartup<Startup>();
            using (var server = new TestServer(hostBuilder))
            {
                HttpClient client = server.CreateClient();
                var response = await client.GetAsync("/ping");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Assert.Equals("pong", content);
            }

        }
}