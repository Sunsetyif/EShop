﻿using EShop.Services;
using EShop.Web.Models;
using EShop.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace EShop.Web.Controllers
{



    public class HomeController : Controller
    {


        CategoryService categoryService = new CategoryService();

        public HomeController()
        {

        }
        
        public ActionResult Index()
        {
          //  HomeViewModel model = new HomeViewModel();
            //     model.FeaturedCategories = categoryService.GetFeaturedCategories();

            return RedirectToAction("Index","Shop"/*model*/);
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

        [Authorize(Roles = "admin")]
        public ActionResult UsersWithRoles()
        {

            var context = new ApplicationDbContext();
            var users = context.Users.ToList();


            return View(users);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditRole(string Id)
        {


            var context = new ApplicationDbContext();
            var user = context.Users.Find(Id);
            return View(user);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditRole(ApplicationUser user)
        {


            var context = new ApplicationDbContext();
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();

            return View(user);
        }
        public ActionResult Logout()
        {

           
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Shop");


        }
        public ActionResult MyProfile(string Id)
        {

            var context = new ApplicationDbContext();

            var user = context.Users.Find(Id);
            return View(user);
        }

    }
}