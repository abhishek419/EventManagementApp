using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookFairApplication.Controllers;

namespace BookFairApplication.Tests.Controllers
{
    [TestClass]
    public class EventControllerTest
    {
        [TestMethod]
        public void CreateEvent()
        {
            EventController controller = new EventController();
            ViewResult result = controller.CreateEvent() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
