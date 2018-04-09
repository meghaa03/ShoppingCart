using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class OrderProduct
    {
        [Required]
        public int OrderProductID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double OrderTotal { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        
    }
}