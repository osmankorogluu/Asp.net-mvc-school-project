using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciMVC.Models.EntitiyFaremwork;


namespace OgrenciMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);

        }
        [HttpGet]
        public ActionResult yeniders()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniders(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return View();


        }
        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult dersgetir(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View("dersgetir", ders);


        }
        public ActionResult Guncelle(TBLDERSLER p)
        {

            var klp = db.TBLDERSLER.Find(p.DERSID);
            klp.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");


        }
    }
}