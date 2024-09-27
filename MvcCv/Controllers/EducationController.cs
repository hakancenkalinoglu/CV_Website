using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult AddNewEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewEducation(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            repo.TRemove(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult EditEducation(TblEducation t)
        {
            if(ModelState.IsValid)
            {
                return View("EditEducation");
            }
            var education = repo.Find(x => x.ID == t.ID);
            education.Header = t.Header;
            education.Subheader1 = t.Subheader1;
            education.Subheader2 = t.Subheader2;
            education.GNO = t.GNO;
            education.Date = t.Date;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }
    }


}