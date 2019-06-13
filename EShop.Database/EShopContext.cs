using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Database
{
  public  class EShopContext : DbContext, IDisposable
    {
        public EShopContext() : base("EShopConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Config> Configurations { get; set; }
    }
}
