using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Web.ViewModels
{
    public class NewCategoryViewModels
    {
        public string Name { get; set; }
        public string Descrpiption { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}