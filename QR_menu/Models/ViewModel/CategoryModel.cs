using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR_menu.Models.ViewModel
{
    public class CategoryModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}