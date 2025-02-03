using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR_menu.Models.ViewModel
{
    public class AdminModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable <Admin> Admins { get; set; }
    }
}