using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> ProductList { get; set; }
        public Product Product { get; set; }
        public string ErrorMessage { get; set; }
        public List<Product> PagedProductList { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public double TotalPages { get; set; }
    }
}