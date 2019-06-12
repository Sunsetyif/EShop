using EShop.Services;
using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Web.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        ProductService productService = new ProductService();

        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie != null)
            {
                 //var productIDs = CartProductsCookie.Value;
                //var ids = productIDs.Split('-');
                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();

                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = productService.GetProducts(model.CartProductIDs);
            }
            return View(model);
        }
    }
}