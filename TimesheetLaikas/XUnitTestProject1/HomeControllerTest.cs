using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TimesheetLaikas.Controllers;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XUnitTestProject1
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsIndexViewModelsInViewResult()
        {
            var controller = new HomeController();
            IActionResult result = controller.Index(Model);
            Assert.IsType<ViewResult>(result);
            var viewModel = (result as ViewResult).Model;
            Assert.IsType<Index>(viewModel);
        }
    }
}
