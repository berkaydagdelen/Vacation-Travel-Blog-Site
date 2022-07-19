using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("/Index/");
        }
        public ActionResult BlogSil(int id)
        {

            var deger = c.Blogs.Find(id);
            c.Blogs.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("/Index/");
        }
        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var deger = c.Blogs.Find(id);
            return View("BlogGetir", deger);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var deger = c.Blogs.Find(b.ID);
            deger.Baslik = b.Baslik;
            deger.Tarih = b.Tarih;
            deger.Aciklama = b.Aciklama;
            deger.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("/Index/");

        }
        [Authorize]
        public ActionResult YorumListesi()
        {

            var degerler = c.Yorumlars.ToList();

            return View(degerler);
        }

        public ActionResult YorumSil(int id)
        {
            var deger = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var deger = c.Yorumlars.Find(id);
            return View("YorumGetir", deger);
        }

        public ActionResult YorumYayinla(Yorumlar y)
        {
            var deger = c.Yorumlars.Find(y.ID);
            deger.Durum = 1;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
        [Authorize]
        public ActionResult RehberYorumListesi()
        {
            var deger = c.RehberYorumlars.ToList();
            return View(deger);
        }
        public ActionResult RehberYorumSil(int id)
        {
            var deger = c.RehberYorumlars.Find(id);
            c.RehberYorumlars.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("RehberYorumListesi");
        }
        [Authorize]
        public ActionResult RehberYorumGetir(int id)
        {
            var deger = c.RehberYorumlars.Find(id);
            return View("RehberYorumGetir", deger);

        }

        public ActionResult RehberYorumYayinla(RehberYorumlar r)
        {


            var deger = c.RehberYorumlars.Find(r.ID);
            deger.Durum = 1;
            c.SaveChanges();
            return RedirectToAction("RehberYorumListesi");
        }
        [Authorize]
        public ActionResult RehberListesi()
        {

            var deger = c.Rehbers.ToList();

            return View(deger);

        }
        public ActionResult RehberSil(int id)
        {
            var deger = c.Rehbers.Find(id);
            c.Rehbers.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("RehberListesi");

        }




        [Authorize]
        public ActionResult iletisimListesi()
        {
            var deger = c.İletisims.ToList();
            return View(deger);
        }

        public ActionResult iletisimSil(int id)
        {
            var deger = c.İletisims.Find(id);
            c.İletisims.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("iletisimListesi");

        }

        public ActionResult iletisimGetir(int id)
        {

            var deger = c.İletisims.Find(id);
            return View("iletisimGetir", deger);


        }

        public ActionResult RehberGetir(int id)
        {
            var deger = c.Rehbers.Find(id);

            List<SelectListItem> degerler = (from i in c.Mekanlars.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.MEKANAD,
                                                 Value = i.ID.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;




            return View("RehberGetir", deger);
        }


        public ActionResult RehberGuncelle(Rehber r)
        {


            var deger = c.Rehbers.Find(r.ID);
            deger.Baslik = r.Baslik;
            deger.Aciklama = r.Aciklama;
            deger.Tarih = r.Tarih;
            deger.Fotograf = r.Fotograf;

            var rhb = c.Mekanlars.Where(p => p.ID == r.Mekanlar.ID).FirstOrDefault();
            deger.MekanlarID = rhb.ID;


            c.SaveChanges();
            return RedirectToAction("RehberListesi");
        }



        public ActionResult HakkimizdaGetir(int id)
        {
            var deger = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", deger);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var deger = c.Hakkimizdas.Find(h.ID);
            deger.FotoUrl = h.FotoUrl;
            deger.Aciklama = h.Aciklama;
            c.SaveChanges();
            return RedirectToAction("HakkimizdaGetir/1");


        }


        [HttpGet]
        public ActionResult YeniRehber()
        {
            List<SelectListItem> degerler = (from i in c.Mekanlars.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.MEKANAD,
                                                 Value = i.ID.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;


            return View();
        }
        [HttpPost]
        public ActionResult YeniRehber(Rehber r)
        {
            c.Rehbers.Add(r);
            c.SaveChanges();
            return RedirectToAction("RehberListesi");
        }



    }
}