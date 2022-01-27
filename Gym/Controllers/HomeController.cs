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

        public ActionResult Slaves(string SearchRequest)
        {
            IQueryable<Slave> filteredItems = db.Slaves
                .Include(v => v.Master);

            if (SearchRequest != null && SearchRequest != "" && SearchRequest.Length > 1)
            {
                filteredItems = filteredItems
                .Where(v => v.Name.ToLower().Contains(SearchRequest.ToLower())
                || v.Surname.ToString().Contains(SearchRequest.ToLower()));
            }

            return View(filteredItems);
        }

        public ActionResult Masters(string SearchRequest)
        {
            IQueryable<GymMaster> filteredItems = db.GymMasters
                .Include(v => v.Slaves);

            if (SearchRequest != null && SearchRequest != "" && SearchRequest.Length > 1)
            {
                filteredItems = filteredItems
                .Where(v => v.Name.ToLower().Contains(SearchRequest.ToLower())
                || v.Surname.ToString().Contains(SearchRequest.ToLower()));
            }

            return View(filteredItems);
        }

        [HttpGet]
        public ActionResult AddSlave()
        {
            ViewBag.MasterList = new SelectList(db.GymMasters, "Id", "Surname");
            return View();
        }

        [HttpPost]
        public ActionResult AddSlave(Slave newSlave)
        {
            GymMaster masterOfTheSlave = db.GymMasters.Find(newSlave.MasterId);
            newSlave.Master = masterOfTheSlave;

            db.Slaves.Add(newSlave);
            db.Entry(newSlave).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddMaster()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMaster(GymMaster newMaster)
        {
            db.GymMasters.Add(newMaster);
            db.Entry(newMaster).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RemoveSlave(int? Id)
        {
            Slave s = db.Slaves.Find(Id);
            db.Slaves.Remove(s);
            db.Entry(s).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Slaves");
        }
    }
}