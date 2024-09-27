using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult SocialMedia()
        {
            var values = db.TblSocialMedias.Where(x => x.Active == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values =db.TblEducations.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skills()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Interest()
        {
            var values = db.tblInterests.ToList();
            return PartialView(values); 
        }
        public PartialViewResult Certificates()
        {
            var values = db.TblCertificates.ToList();
            return PartialView(values); 
        }
        [HttpGet]
        public PartialViewResult Contact() { 
            return PartialView();

        }
        [HttpPost]
        public PartialViewResult Contact(TblContact t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContacts.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}