using EShop.Services;
using EShop.Web.Models;
using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        CategoryService categoryService = new CategoryService();

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
       //     model.FeaturedCategories = categoryService.GetFeaturedCategories();

            return View(model);
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Delivery()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}