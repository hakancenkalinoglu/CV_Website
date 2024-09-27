using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<TblCertificate> repo = new GenericRepository<TblCertificate>();
        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(certificate);
        }
        [HttpPost]
        public ActionResult GetCertificate(TblCertificate t)
        {  
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddNewCertificate()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCertificate(TblCertificate p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            repo.TRemove(certificate);
            return RedirectToAction("Index");
        }
    }
}