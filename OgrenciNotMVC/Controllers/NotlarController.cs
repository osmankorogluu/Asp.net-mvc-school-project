using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciMVC.Models.EntitiyFaremwork;
using OgrenciMVC.Models;

namespace OgrenciMVC.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR p)
        {
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult notlargetir(int id)
        {
            var kulup = db.TBLNOTLAR.Find(id);
            return View("notlargetir", kulup);

        }
        [HttpPost]
        public ActionResult notlargetir(TBLNOTLAR p, Class1 model, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                //İŞLEM1
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                //İŞLEM2
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.PROJE;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");

            }
            return View();


        }
    }
}
