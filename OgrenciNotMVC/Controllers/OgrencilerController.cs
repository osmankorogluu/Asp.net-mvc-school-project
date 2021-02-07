using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciMVC.Models.EntitiyFaremwork;

namespace OgrenciMVC.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenci = db.TBLOGRENCİLER.ToList();
            return View(ogrenci);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()




                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCİLER p)
        {
            db.TBLOGRENCİLER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCİLER.Find(id);
            db.TBLOGRENCİLER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ogrencigetir(int id)
        {
            var ogrenci = db.TBLOGRENCİLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()




                                             }).ToList();
            return View("ogrencigetir", ogrenci);

        }
        public ActionResult Guncelle(TBLOGRENCİLER p)
        {
            var ogr = db.TBLOGRENCİLER.Find(p.OGRENCİID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRCİNSİYET = p.OGRCİNSİYET;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");
        }


    }
}
