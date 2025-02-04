using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class ÜrünController : Controller
    {
        // GET: Ürün
        MvcDbStokEntities1 db=new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler=db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> degerler=(from i in db.TBLKATEGORILER.ToList() select new SelectListItem
            {
                Text=i.KATEGORIAD,
                Value=i.KATEGORID.ToString()
            }).ToList();
            ViewBag.dgr=degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniÜrün(TBLURUNLER p1)
        {
            var ktg=db.TBLKATEGORILER.Where(m=>m.KATEGORID
            ==p1.TBLKATEGORILER.KATEGORID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
           return View("UrunGetir",urn);

        }
        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urn = db.TBLURUNLER.Find(p.URUNID);
            urn.URUNAD = p.URUNAD;
            urn.MARKA = p.MARKA;
            urn.STOK = p.STOK;
            urn.FIYAT = p.FIYAT;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORID
           == p.TBLKATEGORILER.KATEGORID).FirstOrDefault();
            urn.URUNKATEGORI = ktg.KATEGORID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}