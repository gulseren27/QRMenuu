using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QR_menu.Controllers
{
   
    public class CategoryController : Controller
    {

        Qr_MenuDBEntities db = new Qr_MenuDBEntities();
        // GET: Category
        [Authorize]
        public ActionResult Index()
        {
            var categories = db.Category.ToList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(string CName, string Description)
        {
            try
            {
                if (!string.IsNullOrEmpty(CName) && !string.IsNullOrEmpty(Description))
                {
                    var category = new Category
                    {
                        CName = CName,
                        Description = Description
                    };

                    db.Category.Add(category);  // Veritabanına ekle
                    db.SaveChanges();           // Değişiklikleri kaydet

                    return Json(new { success = true, message = "Kategori başarıyla eklendi!" });
                }

                return Json(new { success = false, message = "Lütfen tüm alanları doldurun." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        public ActionResult Delete(int id)
        {
            var categorie = db.Category.Find(id);
            db.Category.Remove(categorie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var ktgr = db.Category.Find(id);
            return View("GetCategory", ktgr);
        }

        public ActionResult GUNCELLE(Category c)
        {

            if (ModelState.IsValid)
            {
                // Veritabanında ilgili kategoriyi bul
                var categoryInDb = db.Category.FirstOrDefault(x => x.CategoryID == c.CategoryID);

                // Eğer kategori bulunamazsa hata mesajı döndür
                if (categoryInDb == null)
                {
                    return HttpNotFound("Kategori bulunamadı.");
                }

                // Kategoriyi güncelle
                categoryInDb.CName = c.CName;
                categoryInDb.Description = c.Description;

                // Veritabanına kaydet
                db.SaveChanges();

                // Güncelleme sonrası kullanıcıyı başka bir sayfaya yönlendir
                return RedirectToAction("Index"); // Ya da başka bir sayfa
            }

            // Eğer model geçerli değilse formu tekrar göster
            return View(c);


        }
    }
}