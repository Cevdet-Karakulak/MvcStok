using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db=new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p2)
        {
            db.TBLMUSTERILER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}