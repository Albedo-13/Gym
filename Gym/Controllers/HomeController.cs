using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Gym.Models;
using System.Web.Mvc;

namespace Gym.Controllers
{
    public class HomeController : Controller
    {
        public GymContext db = new GymContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slaves()
        {
            var dbInfo = db.Slaves
                .Include(v => v.Master);

            return View(dbInfo);
        }

        public ActionResult Masters()
        {
            var dbInfo = db.GymMasters
                .Include(v => v.Slaves);

            return View(dbInfo);
        }
    }
}