using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class RehberController : Controller
    {
        // GET: Rehber
        Context c = new Context();
        public ActionResult Index(int id)
        {
            var deger = c.Rehbers.Where(p => p.MekanlarID == id).OrderByDescending(p=>p.ID).ToList();
            return View(deger);
        }

        public ActionResult RehberDetay(int id)
        {

            var deger = c.Rehbers.Where(p => p.ID == id).ToList();
            return View(deger);
        }
        public PartialViewResult SonRehberGonderi(int id)
        {
            var deger = c.Rehbers.Where(p => p.MekanlarID == id).OrderByDescending(p => p.ID).Take(5).ToList();

            return PartialView(deger);
        }

        public PartialViewResult SonBloglar()
        {
            var deger = c.Blogs.OrderByDescending(p => p.ID).Take(10).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Yorumlar(int id)
        {
            var deger = c.RehberYorumlars.Where(p => p.RehberID == id && p.Durum==1).ToList();
            return PartialView(deger);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(RehberYorumlar y)
        {
            c.RehberYorumlars.Add(y);
            c.SaveChanges();
            return PartialView();

        }
    }
}