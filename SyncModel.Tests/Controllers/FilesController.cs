using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SyncModel.Tests.Controllers
{
    [TestClass]
   public class FilesController
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            FilesController controller = new FilesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(null, result.ViewBag.Message);
        }
    }
}
