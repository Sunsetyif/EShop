using EShop.Database;
using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services
{
    public class ConfigurationsService
    {
        public static ConfigurationsService Instance
        {
            get
            {

                if (instance == null) instance = new ConfigurationsService();
                return instance;
            }
        }

        private static ConfigurationsService instance { get; set; }
        public ConfigurationsService()
        {

        }
        public Config GetConfig(string Key)
        {
            using (var context = new EShopContext())
            {
                return context.Configurations.Where(x => x.Key == Key).FirstOrDefault();
            }
        }
    }

}
