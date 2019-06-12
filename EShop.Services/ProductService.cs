using EShop.Database;
using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EShop.Services
{
   public class ProductService
    {
        public void UpdateProduct(Product product)
        {
            using (var context = new EShopContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void SaveProduct(Product product)
        {
            using (var context = new EShopContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.Products.Add(product);
                context.SaveChanges();
            }

        }
        public List<Product> GetProducts()
        {
          
            using (var context = new EShopContext())
            {
                return context.Products.Include(x=>x.Category).ToList();
                
            }
        }
        public List<Product> GetProducts(List<int>IDs)
        {

            using (var context = new EShopContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();

            }
        }
        public Product GetProduct(int ID)
        {
            using (var context = new EShopContext())
            {

                return context.Products.Where(x=>x.ID==ID).Include(x=>x.Category).FirstOrDefault();
            }
        }
        public void DeleteProduct(int ID)
        {
            using (var context = new EShopContext())
            {
                var product = context.Products.Find(ID);

                //   context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

    }
}
