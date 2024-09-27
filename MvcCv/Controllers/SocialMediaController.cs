using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia> ();
        public ActionResult Index()
        {
            var socialMedia = repo.List();
            return View(socialMedia);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            var socialMedia = repo.Find(x=> x.ID == id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult EditSocialMedia(TblSocialMedia p)
        {
            var socialMedia = repo.Find(x =>  x.ID == p.ID);
            socialMedia.Ad = p.Ad;
            socialMedia.Link = p.Link;
            socialMedia.Icon = p.Icon;
            socialMedia.Active = p.Active;
            repo.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
        
        public ActionResult StatusSocialMedia(TblSocialMedia p) 
        {
            var socialMedia = repo.Find(x=> x.ID == p.ID);
            if(socialMedia.Active == true)
            {
                socialMedia.Active = false;
            }else if(socialMedia.Active == false)
            {
                socialMedia.Active = true;

            }
            repo.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}