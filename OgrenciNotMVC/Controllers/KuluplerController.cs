using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciMVC.Models.EntitiyFaremwork;

namespace OgrenciMVC.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities klb = new DbMvcOkulEntities ();
        public ActionResult Index()
        {
            var kulupler = klb.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult yenikulup ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikulup (TBLKULUPLER p)
        {
            klb.TBLKULUPLER.Add(p);
            klb.SaveChanges();
            return View();
        
        }
        public ActionResult Sil(int id)
        {
            var kulup = klb.TBLKULUPLER.Find(id);
            klb.TBLKULUPLER.Remove(kulup);
            klb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult kulupgetir(int id)
        {
            var kulup = klb.TBLKULUPLER.Find(id);
            return View("kulupgetir", kulup);
        
        }
        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = klb.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            klb.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}