using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR_menu.Helper
{
    public class UserHelper
    {
        public static Admin GetCurrentUser()
        {
            return (Admin)System.Web.HttpContext.Current.Session["user"];

        }
        public static void SetCurrentUser(Admin currentUser)
        {
            System.Web.HttpContext.Current.Session["user"] = currentUser;

        }
    }
}