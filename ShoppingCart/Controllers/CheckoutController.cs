using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CheckoutController : Controller
    {
        private StoreContext db = new StoreContext();

        /// <summary>
        /// Asks the user to enter delivery address for order placement
        /// </summary>
        /// <returns></returns>
        // GET: Checkout
        public ActionResult Index()
        {
            int CartID = (int)Session["Customer"];
            var cart = db.Carts.Find(CartID);

            if (cart.CartTotal == 0)
            {
                return View("CartEmptyError");
            }
            else
            {
                return View("GetDeliveryAddress");
            }
            
        }

        /// <summary>
        /// Adding products from cart to order table
        /// </summary>
        /// <param name="houseStreetBlock"></param>
        /// <param name="state"></param>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public ActionResult OrderPlacement(string houseStreetBlock, string state, string pincode)
        {
            string deliveryAddress = houseStreetBlock + "," + state + "," + pincode;
            
            int CartID = (int)Session["Customer"];
            var cart = db.Carts.Find(CartID);
            if(cart.CartTotal==0)
            {
                return View("CartEmptyError");
            }

            //updating Order table
            Order order = new Order()
            {
                TotalAmount = cart.CartTotal,
                CustomerID = (int)Session["Customer"],
                DeliveryAddress = deliveryAddress
            };
            db.Orders.Add(order);
            db.SaveChanges();
            var cartProducts = db.CartProducts.Where(p => p.CartID == CartID);

            //updating OrderProduct table
            int customersLastOrderID = db.Orders.Max(p => p.OrderID);
                        
            foreach (var item in cartProducts)
            {
                
                OrderProduct orderProduct = new OrderProduct()
                {
                    Quantity = item.Quantity,
                    ProductID = item.ProductID,
                    OrderID = customersLastOrderID,
                    
                };

                db.OrderProducts.Add(orderProduct);

            }
            db.SaveChanges();

            //Update Cart
            Cart cartToUpdate = db.Carts.Find(CartID);
            cartToUpdate.CartTotal = 0;
            db.SaveChanges();

            //Remove from CartProduct
            db.CartProducts.RemoveRange(db.CartProducts.Where(x => x.CartID == CartID));
            db.SaveChanges();
            return View("OrderSuccessful");

        }

    }
}