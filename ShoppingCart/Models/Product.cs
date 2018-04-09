using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;  
using System.Web;

namespace ShoppingCart.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int VariantID { get; set; }
        public int CategoryID { get; set; }

        public virtual Variant Variant { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<CartProduct> CartProduct { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        
    }
}