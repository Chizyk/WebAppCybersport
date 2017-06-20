using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProjectR.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Наша страница контактов.";

            return View();
        }

        public ActionResult Cybersport()
        {
            ViewBag.Message = "Общая информация о киберспорте";

            return View();
        }


    }
}