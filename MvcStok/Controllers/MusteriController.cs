using System.Linq;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db=new MvcDbStokEntities1();
        public ActionResult Index(string p)
        {
            var degerler=from d in db.TBLMUSTERILER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler=degerler.Where(m=>m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
           // var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p2);
            db.SaveChanges();
            return RedirectToAction
                ("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mus = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERIAD= p1.MUSTERIAD;
            mus.MUSTERISOYAD= p1.MUSTERISOYAD;            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}