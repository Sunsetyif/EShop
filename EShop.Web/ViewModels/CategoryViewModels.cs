using EShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Web.ViewModels
{
    public class NewCategoryViewModels
    {
        [Required]
        [MinLength(5), MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Descrpiption { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
    public class CategorySearchViewModel
    {
        public List<Category> Categories { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }
}