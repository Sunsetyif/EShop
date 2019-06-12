using EShop.Entities;
using EShop.Services;
using EShop.Web.ViewModels;
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
        
        public ActionResult ProductTable(string Search)
        {
            List<Product> products = productService.GetProducts();
            if(string.IsNullOrEmpty(Search) == false)
            { 
            products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
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
            CategoryService categoryService = new CategoryService();
            var categories = categoryService.GetCategories();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModels model)
        {
            CategoryService categoryService = new CategoryService();
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Descrpiption;
            newProduct.Price = model.Price;
            newProduct.Category = categoryService.GetCategory(model.CategoryID);
            
            productService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productService.GetProduct(ID);    
            return PartialView(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}