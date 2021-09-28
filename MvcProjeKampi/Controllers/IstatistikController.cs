using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            Context db = new Context();

            //SORU 1'İN CEVABI
            var sayi = db.Categories.Count();
            ViewBag.deger1 = sayi;

            //SORU 2'NİN CEVABI
            var baslik = db.Headings.Where(x => x.Category.CategoryName == "yazılım").Count();
            ViewBag.deger2 = baslik;

            //SORU 3'ÜN CEVABI
            var yazarSayisi = db.Writers.Where(x => x.WriterName.Contains("a")).Count();
            ViewBag.deger3 = yazarSayisi;

            //SORU 4'ÜN CEVABI --Doğru sonucu elde edemedim 
            //var id = db.Headings.GroupBy(x => x.CategoryID)
            //            .Select(group => new
            //            {
            //                maxKullanilanId = group.Key,
            //                Count = group.Count()
            //            })
            //            .OrderBy(x => x.maxKullanilanId);


           

                //SORU 5'İN CEVBI
            var trueSayisi = db.Categories.Where(x => x.CategoryStatus == true ).Count();
            var falseSayisi = db.Categories.Where(x => x.CategoryStatus == false).Count();
            var sonuc = trueSayisi - falseSayisi;
            ViewBag.deger5 = sonuc;


            return View();
        }
    }
}