using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
       
        GenericRepository<TblSkill> repo = new GenericRepository<TblSkill>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddNewSkill()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddNewSkill(TblSkill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            TblSkill t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            TblSkill t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditSkill(TblSkill t)
        {
            var skill = repo.Find(x => x.ID == t.ID);
            skill.Skill = t.Skill;
            skill.Ratio = t.Ratio;
            repo.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}