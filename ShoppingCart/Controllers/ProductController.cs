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
using ShoppingCart.Shared;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext db = new StoreContext();

        /// <summary>
        /// Shows product details
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        // GET: Product
        public ActionResult Index(int? page)
        {
            var product = db.Products.Include(p => p.Category).Include(p => p.Variant);
            
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.PageSize = 5;
            viewModel.PageNumber = (page ?? 1);
            viewModel.ProductList = product.ToList();

            CustomPaging customPagingObj = new CustomPaging();
            viewModel.TotalPages = Math.Ceiling((double)viewModel.ProductList.Count() / (double)viewModel.PageSize);
            viewModel.PagedProductList = customPagingObj.PagedList(viewModel.ProductList.ToList(), viewModel.PageNumber, viewModel.PageSize);
            return View(viewModel);

        }

        /// <summary>
        /// Searches a product by its name and description based on text from Search Box
        /// </summary>
        /// <param name="SearchBox"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SearchProduct(string SearchBox,int? page)
        {
            var products = from p in db.Products
                           select p;
            if (!String.IsNullOrEmpty(SearchBox))
            {
                products = products.Where(p => p.Description.Contains(SearchBox)
                                       || p.ProductName.Contains(SearchBox));
            }

            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.PageSize = 5;
            viewModel.PageNumber = (page ?? 1);
            viewModel.ProductList = products.ToList();

            CustomPaging customPagingObj = new CustomPaging();
            viewModel.TotalPages = Math.Ceiling((double)viewModel.ProductList.Count() / (double)viewModel.PageSize);
            viewModel.PagedProductList = customPagingObj.PagedList(viewModel.ProductList.ToList(), viewModel.PageNumber, viewModel.PageSize);

            return View("Index",viewModel);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(Session["Customer"]!=null)
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Authentication");
            }
        }

        /// <summary>
        /// Shows Category-wise product list
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public ActionResult CategoryProductList(int categoryID)
        {
            if(Session["Customer"]!=null)
            {
                List<Product> categoryProductList = db.Products.Where(x => x.CategoryID == categoryID).ToList();
                return View("DisplayCategoryProducts", categoryProductList);
            }
            else
            {
                return RedirectToAction("Index", "Authentication");
            }
            
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName");
            ViewBag.VariantID = new SelectList(db.Variants, "VariantID", "Color");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Description,ProductName,Price,Quantity,ImageUrl,VariantID,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.VariantID = new SelectList(db.Variants, "VariantID", "Color", product.VariantID);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.VariantID = new SelectList(db.Variants, "VariantID", "Color", product.VariantID);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Description,ProductName,Price,Quantity,ImageUrl,VariantID,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.VariantID = new SelectList(db.Variants, "VariantID", "Color", product.VariantID);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
