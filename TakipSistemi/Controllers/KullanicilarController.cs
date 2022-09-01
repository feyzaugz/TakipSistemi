using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakipSistemi.Models.Siniflar;

namespace TakipSistemi.Controllers
{
    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar
        Context db = new Context();
        int sayac = 0;
        public ActionResult Index()
        {
            var degerler = db.Kullanicilar.Where(x => x.Durum == true).Where(y => y.YetkiId == 2).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            ViewBag.YetkiId = new SelectList(db.Yetkiler, "YetkiId", "YetkiAdi");
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciEkle(Kullanici kullanici)
        {
            db.Kullanicilar.Add(kullanici);
            ViewBag.YetkiId = new SelectList(db.Yetkiler, "YetkiId", "YetkiAdi");
            kullanici.Durum = true;
            foreach (var item in db.Kullanicilar)
            {
                if (kullanici.KullaniciMail == item.KullaniciMail)
                {
                    sayac++;
                    return RedirectToAction("KullaniciHata", "Kullanicilar");
                }
            }

            if (sayac == 0)
            {
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult KullaniciHata()
        {
            return View();
        }
        public ActionResult KullaniciGetir(int id)
        {
            ViewBag.YetkiId = new SelectList(db.Yetkiler, "YetkiId", "YetkiAdi");
            var prs = db.Kullanicilar.Find(id);
            return View("KullaniciGetir", prs);
        }

        [HttpPost]
        public ActionResult KullaniciGuncelle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                kullanici.Durum = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YetkiId = new SelectList(db.Yetkiler, "YetkiId", "YetkiAdi");
            return View(kullanici);
        }
        public ActionResult KullaniciSil(int id)
        {
            var deger = db.Kullanicilar.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}