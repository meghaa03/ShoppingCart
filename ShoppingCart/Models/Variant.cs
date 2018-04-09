using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Variant
    {
        public int VariantID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        
    }
}