using Microsoft.AspNetCore.Mvc;

namespace WeFinance.Web.Controllers
{
    public class HomeController : WeFinanceControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}