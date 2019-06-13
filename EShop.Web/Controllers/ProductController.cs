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
        //ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string Search,int? pageNo)
        {
//ProductService;
            ProductSearchViewModel model = new ProductSearchViewModel();
            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
          //Equal above
            //if (pageNo.HasValue)
            //{
            //    if (pageNo.Value > 0)
            //    {
            //        model.PageNo = pageNo.Value;
            //    }
            //    else
            //    {
            //        model.PageNo = 1;
            //    }
            //}
            //else
            //{
            //    model.PageNo = 1;
            //}
            model.Products = ProductService.Instance.GetProducts(model.PageNo);
           
            //List<Product> products = productService.GetProducts();
            if (string.IsNullOrEmpty(Search) == false)
            {
                model.SearchTerm = Search;
                model.Products = model.Products.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
                //products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }
            //foreach (var p in products)
            //{
            //    if(p.Name == Search)
            //    {  }
            //}
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();

            model.AvailableCategories = CategoryService.Instance.GetAllCategories();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
           // CategoryService categoryService = new CategoryService();
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = categoryService.GetCategory(model.CategoryID);
            newProduct.ImageURL = model.ImageURL;

            ProductService.Instance.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            //EditProductViewModel model = new EditProductViewModel();
            var product = ProductService.Instance.GetProduct(ID);
            return PartialView(product);
            
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductService.Instance.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductService.Instance.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}