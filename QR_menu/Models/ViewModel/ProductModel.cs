using QR_menu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR_menu.Models.ViewModel
{
    public class ProductModel
    {
        public virtual Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}