using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public double TotalAmount { get; set; }
        public int CustomerID { get; set; }
        public string DeliveryAddress { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}