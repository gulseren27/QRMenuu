using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR_menu.Models.ViewModel
{
    public class ClassModel
    {
        public int TotalCategories { get; set; }
        public int TotalProducts { get; set; }
   
        public IEnumerable<AdminModel> Admins { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}