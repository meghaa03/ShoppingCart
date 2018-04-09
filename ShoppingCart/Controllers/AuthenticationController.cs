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
    public class AuthenticationController : Controller
    {
        private StoreContext db = new StoreContext();
        // GET: Authentication
        public ActionResult Index()
        {
            return View("Login");
        }

        /// <summary>
        /// Performs user Login and sets his/her session
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ActionResult AuthenticateUser(string username,string password)
        {
            
            var customers = from c in db.Customers
                            select c;

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                Customer customer = customers.Where(c => c.Username == username
                                       && c.Password == password).FirstOrDefault();
                
                if (customer != null)
                {
                    
                    Session["Customer"] = customer.CustomerID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    
                    return View("Login");
                }
            }
            else
            {
                
                return View("Login");
            }
        }

        /// <summary>
        /// Destroys user session and takes him/her to Home Page
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public ActionResult Logout(int session)
        {
            Session["Customer"] = null;
            return RedirectToAction("Index","Home");
        }
    }
}