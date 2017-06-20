using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjectR.Models;
using System.Data.Entity;

namespace WebProjectR.Controllers
{
    public class TeamController : Controller
    {

        Context db = new Context();

        // GET: Tiam
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public ActionResult CreatePlayer()
        {
            // Формируем список стран для передачи в представление
            SelectList country = new SelectList(db.Countrys, "IdCountry", "NameCountry");
            ViewBag.Countrys = country;

            SelectList position = new SelectList(db.Positions, "IdPosition", "NamePosition");
            ViewBag.Positions = position;
            return View();
        }


        public ActionResult CreatePlayer(Player player)
        {

            if (ModelState.IsValid)
            {
               
                if (player.Position.NamePosition == "Капитан команды")
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                }

               

            }
            
           

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        //[Authorize(Roles = "user")]
        public ActionResult Create()
        {
            // Формируем список дисциплин для передачи в представление
            SelectList disc = new SelectList(db.Dicss, "IdDicsipline", "NameDiscipline");
            ViewBag.Dicsciplines = disc;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team, PlayerTeam player)
        {
            List<Team> t = db.Teams.ToList();

            if (ModelState.IsValid)
            {
                //Добавляем команду
                db.Teams.Add(team);
                db.SaveChanges();

                return RedirectToAction("Index", "Manage");

            }


            return View();
        }


        [HttpGet]
        public ActionResult AddPlayer()
        {
            // 

            SelectList teams = new SelectList(db.Teams, "IdTeam", "NameTeam");
            ViewBag.Teams = teams;

            // Формируем список игроков для добавления в команду
            SelectList play = new SelectList(db.Players, "IdPlayer", "NamePlayer");
            ViewBag.Players = play;
            return View();


        }

        [HttpPost]
        public ActionResult AddPlayer(PlayerTeam playerteame)
        {
            //Добавляем команду
            db.PlayerTeams.Add(playerteame);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public ActionResult AddPlayer(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Player player = db.Players.Find(id);
        //    if (player != null)
        //    {
        //        SelectList teams = new SelectList(db.Teams, "IdTeam", "NameTeam",player.TeamId);
        //        ViewBag.Teams = teams;
        //        return View(player);
        //    }

        //    return View();

        //}

        //[HttpPost]
        //public ActionResult AddPlayer(Player player)
        //{
        //    db.Entry(player).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return View();
        //}

        [HttpGet]
        public ActionResult DellTeam(int id)
        {
            Team t = db.Teams.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }

            return View(t);
        }

        [HttpPost, ActionName("DellTeam")]
        public ActionResult DeleteConfirmed(int id)
        {
            Team t = db.Teams.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }
            db.Teams.Remove(t);
            db.SaveChanges();

            return RedirectToAction("Index", "Manage");
        }

        [HttpPost]
        public ActionResult TeamSearch(string name)
        {
            var allteams = db.Teams.Where(a => a.NameTeam.Contains(name)).ToList();
            if (allteams.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allteams);
        }

        [HttpGet]
        public ActionResult EditTeam(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Team team = db.Teams.Find(id);
            if (team != null)
            {
                SelectList dics = new SelectList(db.Teams, "IdDicsipline", "NameDiscipline", team.DicsId);
                ViewBag.Dicss = dics;
                return View(team);
            }

            return RedirectToAction("Index", "Manage");
        }

        [HttpPost]
        public ActionResult EditTeam(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Manage");
        }
    }
}