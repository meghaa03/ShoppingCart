using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Cart
    {
        [Key]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public double CartTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }

    }
}