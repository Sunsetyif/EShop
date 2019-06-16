using EShop.Entities;
using EShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new EShopContext())
            {
                return context.Categories.Where(x => x.isFeatured).ToList();
            }
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
                return context.Categories.Include(x=>x.Products)
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
        public List<Category> GetCategories(string search, int pageNo)
        {
            int pageSize = 3;

            using (var context = new EShopContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null &&
                         category.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.ID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.Products)
                         .ToList();
                }
                else
                {
                    return context.Categories
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
            }
        }
        public int GetCategoriesCount(string search)
        {
            using (var context = new EShopContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null &&
                         category.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Categories.Count();
                }
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
