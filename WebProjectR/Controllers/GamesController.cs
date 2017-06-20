using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProjectR.Views.Games
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Dota2()
        {
            ViewBag.Message = "Игра Dota 2";

            return View();
        }

        public ActionResult Lol()
        {
            ViewBag.Message = "Игра League of legends";

            return View();
        }

        public ActionResult CSGO()
        {
            ViewBag.Message = "Игра CS: GO";

            return View();
        }
    }
}