using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakipSistemi.Models.Siniflar;

namespace TakipSistemi.Controllers
{
    public class BilgilerimController : Controller
    {
        // GET: Bilgilerim
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
    }
}