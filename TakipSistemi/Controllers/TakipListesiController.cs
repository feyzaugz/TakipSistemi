using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakipSistemi.Models.Siniflar;

namespace TakipSistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TakipListesiController : Controller
    {
        // GET: TakipListesi
        Context db = new Context();
        public ActionResult Index()
        {
            var deger = db.Takipler.ToList();
            return View(deger);
        }
        public ActionResult VeriGetir(int id)
        {
            var veri = db.Takipler.Where(x=>x.TakipId==id).ToList();
            return View(veri);
        }
        //public ActionResult VeriGuncelle(int id)
        //{
        //    var tkp = db.Takipler.Find(id);
        //    tkp.TalepNo = takip.TalepNo;
        //    tkp.Tanim=takip.Tanim;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}