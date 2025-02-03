using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QR_menu.Models.ViewModel;

namespace QR_menu.Controllers
{
   //[Authorize]
    public class AdminController : Controller
    {
        Qr_MenuDBEntities db = new Qr_MenuDBEntities();
        ClassModel c = new ClassModel();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            // Veritabanından toplam kategori ve ürün sayılarını al
            int totalCategories = db.Category.Count();
            int totalProducts = db.Product.Count();

            // Admin bilgilerini al
            var adminDetails = db.Admin
                .Select(a => new AdminModel
                {
                    ID = a.AdminID,
                    Username = a.UserName,
                    Password = a.Password
                }).ToList();

            // ViewModel'e aktar
            var model = new ClassModel
            {
                TotalCategories = totalCategories,
                TotalProducts = totalProducts,
                Admins = adminDetails
            };

            return View(model);
        
    }
        public ActionResult GetAdmin(int id)
        {
            var a = db.Admin.Find(id);
            return View("GetAdmin",a);
        }
        public ActionResult Update(Admin a)
        {
            var admin = db.Admin.Find(a.AdminID);
            admin.UserName = a.UserName;
            admin.Password = a.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}