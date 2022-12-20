using KisiselWebSitesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KisiselWebSitesi.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.AnaSayfas.ToList();
            return View(deger);
        }
        public ActionResult AnasayfaGetir(int id)
        {
            var ag = c.AnaSayfas.Find(id);
            return View("AnasayfaGetir", ag);
        }
        public ActionResult AnaSayfaGuncelle(AnaSayfa g)
        {
            var ag = c.AnaSayfas.Find(g.id);
            ag.isim = g.isim;
            ag.iletisim = g.iletisim;
            ag.aciklama = g.aciklama;
            ag.profil = g.profil;
            ag.unvan = g.unvan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IkonListesi()
        {
            var deger = c.Ikonlars.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniIkon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniIkon(Ikonlar p)
        {
            c.Ikonlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
        public ActionResult IkonGetir(int id)
        {
            var ig = c.Ikonlars.Find(id);
            return View("IkonGetir", ig);
        }
        public ActionResult IkonGuncelle(Ikonlar g)
        {
            var ig = c.Ikonlars.Find(g.id);
            ig.ikon = g.ikon;
            ig.link = g.link;
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
        public ActionResult IkonSil(int id)
        {
            var sl = c.Ikonlars.Find(id);
            c.Ikonlars.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
    }
}