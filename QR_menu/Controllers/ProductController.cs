using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QR_menu.Controllers
{
    
    public class ProductController : Controller
    {

        Qr_MenuDBEntities db = new Qr_MenuDBEntities();
        // GET: Product


        [Authorize]
        public ActionResult Index()
        {
            var products = db.Product.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> list = (from i in db.Category.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.CName,
                                             Value = i.CategoryID.ToString()
                                         }).ToList();
            ViewBag.dgr = list;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product p, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                // Dosya adı ve yolunu belirle
                string fileName = System.IO.Path.GetFileName(ImageFile.FileName);
                string path = Server.MapPath("~/Images/" + fileName);
                // Dosyayı kaydet
                ImageFile.SaveAs(path);

                // Veritabanında saklanacak yol
                p.Image = "/Images/" + fileName;
            }
            var ctg = db.Category.Where(m => m.CategoryID == p.Category.CategoryID).FirstOrDefault();
            p.Category = ctg;
            db.Product.Add(p);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Ürün başarıyla eklendi!";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var p = db.Product.Find(id);
            db.Product.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            var Urun = db.Product.Find(id);

            List<SelectListItem> degerler = (from i in db.Category.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CName,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("GetProduct", Urun);
        }



        public ActionResult Update(Product p1)
        {
            var urunn = db.Product.Find(p1.PID);
            urunn.PName = p1.PName;
            urunn.Image = p1.Image;
            var ktg = db.Category.Where(m => m.CategoryID == p1.Category.CategoryID).FirstOrDefault();
            urunn.CategoryID = p1.Category.CategoryID;
            urunn.Price = p1.Price;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}