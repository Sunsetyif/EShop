using EShop.Entities;
using EShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductTable(string Search)
        {
            List<Product> products = productService.GetProducts();
            if(string.IsNullOrEmpty(Search) == false)
            { 
            products = products.Where(p => p.Name != null && p.Name.Contains(Search)).ToList();
            }
            //foreach (var p in products)
            //{
            //    if(p.Name == Search)
            //    {  }
            //}
            return PartialView(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productService.SaveProduct(product);
            return View();
        }
    }
}