using EShop.Entities;
using EShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services
{
    public class CategoryService
    {
        public static CategoryService Instance
        {
            get
            {

                if (instance == null) instance = new CategoryService();
                return instance;
            }
        }

        private static CategoryService instance { get; set; }
        public CategoryService()
        {

        }


        public void UpdateCategory(Category category)
        {
            using (var context = new EShopContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void SaveCategory(Category category)
        {
            using (var context = new EShopContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public List<Category> GetAllCategories()
        {
            using (var context = new EShopContext())
            {
                return context.Categories
                        .ToList();
            }
        }

        public List<Category> GetCategories()
        {
            using (var context = new EShopContext())
            {

                return context.Categories.ToList();
            }
        }
        //Recommend products
        //public List<Category> GetFeaturedCategories()
        //{
        //    using (var context = new EShopContext())
        //    {

        //        //return context.Categories.Where(x=>x.);
        //    }
        //}
        public Category GetCategory(int ID)
        {
            using (var context = new EShopContext())
            {

                return context.Categories.Find(ID);
            }
        }
        public void DeleteCategory(int ID)
        {
            using (var context = new EShopContext())
            {
                var category = context.Categories.Find(ID);

                //   context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

    }
}
