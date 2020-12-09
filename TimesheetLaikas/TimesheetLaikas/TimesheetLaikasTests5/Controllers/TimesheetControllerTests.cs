using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimesheetLaikas.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimesheetLaikas.Controllers.Tests
{
    [TestClass()]
    public class TimesheetControllerTests
    {
        [TestMethod()]
        public void TimesheetControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ViewTimesheetsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TimePunchTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PunchInTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PunchOutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Context.Database.EnsureDeleted();
            Context.Database.CloseConnection();
            Context.Dispose();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail(false);
        }
    }
}