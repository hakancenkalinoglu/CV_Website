using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(TblAdmin tblAdmin)
        {
            repo.TAdd(tblAdmin);
            return RedirectToAction("Index");
        }
        public ActionResult AdminDelete(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminUpdate(TblAdmin tblAdmin)
        {
            TblAdmin t = repo.Find(x => x.ID == tblAdmin.ID);
            t.UserName = tblAdmin.UserName;
            t.Password = tblAdmin.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}