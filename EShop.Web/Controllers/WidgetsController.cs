using EShop.Services;
using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Web.Controllers
{
   
    public class WidgetsController : Controller
    {
        //Populyarity = LastIdsAdded
        //Newest = products.OrderByDescending(x => x.Price).ToList();
        // GET: Widgets
        public ActionResult Products(bool isLatestProducts, int? CategoryID)
        {
            ProductWidgetVIewModels model = new ProductWidgetVIewModels();
            model.IsLatestProducts = isLatestProducts;

            if (isLatestProducts)
            {
                model.Products = ProductService.Instance.GetLatestProducts(6);
            }
            else if (CategoryID.HasValue && CategoryID.Value > 0)
            {
                model.Products = ProductService.Instance.GetProductsByCategory(CategoryID.Value, 4);
            }
            else
            {
                model.Products = ProductService.Instance.GetProducts(1, 8);
            }
            return PartialView(model);
        }
    }
}