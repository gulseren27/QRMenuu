using QR_menu.Models.Entity;
using QR_menu.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QR_menu.Controllers
{
    public class MenuController : Controller
    {
        Qr_MenuDBEntities db = new Qr_MenuDBEntities();
        ClassModel c = new ClassModel();
        // GET: Menu
        public ActionResult Index()
        {
            c.Categories = db.Category.ToList();
            c.Products = db.Product.ToList();
            return View(c);
        }
    }
}