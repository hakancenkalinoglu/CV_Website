using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var experiences = repo.List();
            return View(experiences);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience T)
        {
            repo.TAdd(T);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id) 
        {
            TblExperience t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.ID == p.ID);
            t.Header = p.Header;
            t.Subheader = p.Subheader;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}