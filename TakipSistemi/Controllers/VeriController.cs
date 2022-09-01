using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakipSistemi.Models.Siniflar;

namespace TakipSistemi.Controllers
{
    public class VeriController : Controller
    {
        // GET: VeriEkle
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VeriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VeriEkle(Takip takip)
        {
            int takipToplam = db.Takipler.Count();
            db.Takipler.Add(takip);
            takip.DosyaNo = "2022-000" + takipToplam;
            takip.Tarih = DateTime.Now;
            //takip.Yetkili = ;
            //foreach (var item in db.Kullanicilar)
            //{
            //    if ()
            //    {

            //    }
            //}
            takip.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index", "TakipListesi");
        }

    }
}