using log4net;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LogManager.GetLogger(typeof(HomeController)).Info("Приложение запущено");
            return RedirectToAction("Index", "Goods");
        }
    }
}