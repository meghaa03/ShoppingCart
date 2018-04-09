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
    public class CustomerController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Cart);
            return View(customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Carts, "CustomerID", "CustomerID");
            return View();
        }

        /// <summary>
        /// Creates a user if the username doesn't exist already
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Name,Username,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var usernameAlreadyExisting= db.Customers.Where(p => p.Username == customer.Username).FirstOrDefault();
                if (usernameAlreadyExisting == null)
                {

                    db.Customers.Add(customer);
                    db.SaveChanges();

                    int currentCustomerID = db.Customers.Max(p => p.CustomerID);

                    Cart cart = new Cart()
                    {
                        CustomerID = currentCustomerID,
                        CartTotal = 0
                    };
                    db.Carts.Add(cart);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Authentication");
                }
                else
                {
                    return View("UsernameExistingError");
                }
            }

            ViewBag.CustomerID = new SelectList(db.Carts, "CustomerID", "CustomerID", customer.CustomerID);
            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Carts, "CustomerID", "CustomerID", customer.CustomerID);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Name,Username,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Carts, "CustomerID", "CustomerID", customer.CustomerID);
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
