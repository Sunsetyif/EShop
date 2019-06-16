using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIDs { get; set; }
    }
    public class ShopViewModel
    {
        public List<Category> FeaturedCategories { get; set; }
        public int MaximumPrice { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public int? SortBy { get; set; }
        public int? CategoryID { get; set; }

        public Pager Pager { get; set; }
        public string SearchTerm { get; set; }
    }
    public class FilterProductsViewModel
    {
        public List<Product> Products { get; set; }

        public Pager Pager { get; set; }
        public int? SortBy { get; set; }
        public int? CategoryID { get; set; }
        public string SearchTerm { get; set; }



    }
}
