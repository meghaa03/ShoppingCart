using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.ViewModels
{
    public class TopCategoriesProductsViewModel
    {
        public List<Category> TopCategories { get; set; }
        public List<List<Product>> TopProductsForCategories { get; set; }

        public List<Category> OtherCategories { get; set; }
        public List<List<Product>> ProductsForOtherCategories { get; set; }
        
    }
}