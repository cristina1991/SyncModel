using System.Web.Mvc;
using SyncModel.Models;

namespace SyncModel.Controllers
{
    public class HomeController : Controller
    {

        FileMVCdb _db = new FileMVCdb();
        public ActionResult Index()
        {
          


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
       
    }
}
