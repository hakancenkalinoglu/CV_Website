using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcCv.Controllers
{
    
    public class InterestController : Controller
    {
        GenericRepository<tblInterest> repo = new GenericRepository<tblInterest> ();
        // GET: Interest
        [HttpGet]
        public ActionResult Index()
        {
            var interest = repo.List();
            return View(interest);
        }
        [HttpPost]
        public ActionResult Index(tblInterest p)
        {
            var t = repo.Find(x => x.ID == 4);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;    
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}