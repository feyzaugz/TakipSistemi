using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TakipSistemi.Models.Siniflar;

namespace TakipSistemi.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult KullaniciLogin1()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KullaniciLogin1(Kullanici p)
        {

            var bilgiler = c.Kullanicilar.FirstOrDefault(x => x.KullaniciMail == p.KullaniciMail && x.Parola == p.Parola);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciMail, false);
                Session["KullaniciMail"] = bilgiler.KullaniciMail.ToString();
                return RedirectToAction("Index", "TakipListesi");
            }
            else
            {
                return RedirectToAction("KullaniciHata", "Login");
            }

        }

        public ActionResult KullaniciHata()
        {
            return View();
        }

    }
}