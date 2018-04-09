using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class CartProduct
    {
        [Required]
        public int CartProductID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }

    }
}