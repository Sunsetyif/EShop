using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Web.ViewModels
{
    public class ProductWidgetVIewModels
    {
        public List<Product> Products { get; set; }
        public bool IsLatestProducts { get; set; }
    }
}