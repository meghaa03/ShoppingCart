using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.DAL;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CartProductController : Controller
    {
        private StoreContext db = new StoreContext();

        /// <summary>
        /// Displays all the products currently in the Cart if user is Logged In, else takes him/her to Login Page
        /// </summary>
        /// <returns></returns>
        // GET: CartProduct
        public ActionResult Index()
        {
            if(Session["Customer"]!=null)
            {
                var cartproducts = db.CartProducts.Include(c => c.Product);
                return View("CartEntriesView",cartproducts.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Authentication");
            }
            
        }

        /// <summary>
        /// Displays all the products currently in the Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCartEntries(int id)
        {
            var cartEntries = db.CartProducts.Where(x => x.CartID == id).ToList();
            return View("CartEntriesView",cartEntries);
        }
        
        // GET: CartProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Find(id);
            if (cartProduct == null)
            {
                return HttpNotFound();
            }
            return View(cartProduct);
        }

        // GET: CartProduct/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description");
            return View();
        }

        // POST: CartProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartProductID,CartID,ProductID,Quantity")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                db.CartProducts.Add(cartProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", cartProduct.ProductID);
            return View(cartProduct);
        }

        // GET: CartProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Find(id);
            if (cartProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", cartProduct.ProductID);
            return View(cartProduct);
        }

        // POST: CartProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartProductID,CartID,ProductID,Quantity")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", cartProduct.ProductID);
            return View(cartProduct);
        }

        // GET: CartProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Where(x => x.ProductID==id).FirstOrDefault();
            if (cartProduct == null)
            {
                return HttpNotFound();
            }

            return View(cartProduct);
            
        }

        /// <summary>
        /// Removes a product from the cart and decreases its total from Cart total
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: CartProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartProduct cartProduct = db.CartProducts.Where(x => x.ProductID == id).FirstOrDefault();

            Cart cart=db.Carts.Find(cartProduct.CartID);

            cart.CartTotal = cart.CartTotal - (cartProduct.Quantity*cartProduct.Product.Price);

            db.CartProducts.Remove(cartProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
