using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Admins.Where(p => p.ID == 1).ToList();

            return View(degerler);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(iletisim i)
        {
            c.İletisims.Add(i);
            c.SaveChanges();
            return PartialView();
        }

    }
}