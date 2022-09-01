using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakipSistemi.Models.Siniflar;

namespace TakipSistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YoneticiPanelController : Controller
    {
        Context c = new Context();
        int idKul;
        // GET: YoneticiPanel

        public ActionResult Index()
        {
            var mail = (string)Session["KullaniciMail"];
            
            foreach (var item in c.Kullanicilar)
            {
                if (item.KullaniciMail == mail)
                {
                    idKul = item.KullaniciID;
                }
            }

            var degerler = c.Kullanicilar.Find(idKul);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult YoneticiGetir(int id)
        {
            var prs = c.Kullanicilar.Find(id);
            return View("KullaniciGetir", prs);
        }

        [HttpPost]
        public ActionResult YoneticiGuncelle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                c.Entry(kullanici).State = EntityState.Modified;
                kullanici.Durum = true;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

    }
}