using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context b = new Context();
        public ActionResult Index()
        {
            var degerler = b.Blogs.OrderByDescending(p => p.ID).Take(4).ToList();

            return View(degerler);
        }

        public PartialViewResult Partial1()
        {
            var degerler = b.Blogs.OrderByDescending(p => p.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var degerler = b.Blogs.Where(p => p.ID == 1).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial3()
        {
            var degerler = b.Blogs.OrderByDescending(p => p.ID).Take(10).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial4()
        {
            var degerler = b.Blogs.OrderByDescending(p => p.ID).Take(3).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial5()
        {
            var degerler = b.Blogs.Take(3).ToList();
            return PartialView(degerler);
        }

    }
}