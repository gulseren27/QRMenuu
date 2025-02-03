using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QR_menu.Controllers
{
    public class LoginController : Controller
    {
        Qr_MenuDBEntities db = new Qr_MenuDBEntities();
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            // Kullanıcının veritabanında olup olmadığını kontrol edin
            var user = db.Admin.FirstOrDefault(m => m.UserName == UserName && m.Password == Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                // Session'a kullanıcı bilgilerini kaydedin
                Helper.UserHelper.SetCurrentUser(user);
                Session["UserName"] = user.UserName;
                Session["Password"] = user.Password;

                // Başarılı giriş sonrası yönlendirme
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // Giriş başarısızsa hata mesajı göster ve yeniden giriş sayfasına dön
                ViewBag.Error = "Bilgiler yanlış";
                return View("Login"); // Giriş sayfasına geri dön
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }

    }
    }
