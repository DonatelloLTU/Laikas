using TimesheetLaikas.Controllers;

namespace TimesheetLaikas.Controllers.Tests

{
    [TestClass()]
    public class TimesheesControllerTests
    {
        [TestMethod()]
        public void TimesheetControllerTest()
        {

        }

        [TestMethod()]
        public void Index_ReturnsIndexViewModelInViewResultTest()
        {
            var controller = new TimesheetController();
            IActionResult result = controller.Index(Model);
            Assert.IsType<ViewResult>(result);
            var viewModel = (result as ViewResult).Model;
            Assert.IsInstanceOfType<IndexViewModel>(viewModel);
        }

        [TestMethod()]
        public void ViewTimesheetsTest()
        {

        }

        [TestMethod()]
        public void DetailsTest()
        {

        }

        [TestMethod()]
        public void TimePunchTest()
        {

        }

        [TestMethod()]
        public void PunchInTest()
        {

        }

        [TestMethod()]
        public void PunchOutTest()
        {

        }

        [TestMethod()]
        public void CreateTest()
        {

        }

        [TestMethod()]
        public void CreateTest1()
        {

        }

        [TestMethod()]
        public void EditTest()
        {

        }

        [TestMethod()]
        public void EditTest1()
        {

        }

        [TestMethod()]
        public void DeleteTest()
        {

        }
    }
}