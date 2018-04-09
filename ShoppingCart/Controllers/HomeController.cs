using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        /// <summary>
        /// Shows products from top 3 categories and other 3 categories. If data is less, takes the user to products index page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            ViewModels.TopCategoriesProductsViewModel viewModel = new ViewModels.TopCategoriesProductsViewModel();

            //Top 3 categories
            var topCategories = db.Database.SqlQuery<ViewModels.TopCategoriesCountViewModel>("select top(3)CategoryID,count( CategoryID ) as cnt from (select p.CategoryID as CategoryID , o.OrderID from Product p join OrderProduct o on p.ProductID = o.ProductID ) " +
                "as s group by s.CategoryID order by cnt DESC;").ToList();

            if (topCategories.Count() >= 3)
            {
                foreach (var x in topCategories)
                {
                    Category category = db.Category.Where(p => p.CategoryID == x.CategoryID).Single();
                    if (viewModel.TopCategories == null)
                    {
                        viewModel.TopCategories = new List<Category>();
                    }
                    viewModel.TopCategories.Add(category);
                }

                foreach (var i in topCategories)
                {

                    var topProducts = db.Database.SqlQuery<ViewModels.TopProductsCountViewModel>("select top(3)ProductID,count( ProductID ) as cnt from (select p.CategoryID as CategoryID,p.productID as ProductID from Product p join OrderProduct o on p.ProductID = o.ProductID ) as s Where s.CategoryId=" + i.CategoryID + "group by ProductID order by cnt DESC;").ToList();
                    List<Product> productList = new List<Product>();
                    foreach (var j in topProducts)
                    {
                        var product = db.Products.Where(p => p.ProductID == j.ProductID).Single();
                        productList.Add(product);
                    }
                    if (viewModel.TopProductsForCategories == null)
                    {
                        viewModel.TopProductsForCategories = new List<List<Product>>();
                    }
                    viewModel.TopProductsForCategories.Add(productList);

                }

                //Other 3 Categories
                var otherCategories = db.Database.SqlQuery<Category>("select * from Category where CategoryID NOT IN (" + viewModel.TopCategories[0].CategoryID + "," + viewModel.TopCategories[1].CategoryID + "," + viewModel.TopCategories[2].CategoryID + ");").ToList();
                foreach (var x in otherCategories)
                {
                    Category category = db.Category.Where(p => p.CategoryID == x.CategoryID).Single();
                    if (viewModel.OtherCategories == null)
                    {
                        viewModel.OtherCategories = new List<Category>();
                    }
                    viewModel.OtherCategories.Add(category);
                }


                foreach (var i in otherCategories)
                {

                    var otherProducts = db.Database.SqlQuery<ViewModels.TopProductsCountViewModel>("select top(5)ProductID,count( ProductID ) as cnt from (select p.CategoryID as CategoryID,p.productID as ProductID from Product p join OrderProduct o on p.ProductID = o.ProductID ) as s Where s.CategoryId=" + i.CategoryID + "group by ProductID;").ToList();
                    List<Product> productList = new List<Product>();
                    foreach (var j in otherProducts)
                    {
                        var product = db.Products.Where(p => p.ProductID == j.ProductID).Single();
                        productList.Add(product);
                    }
                    if (viewModel.ProductsForOtherCategories == null)
                    {
                        viewModel.ProductsForOtherCategories = new List<List<Product>>();
                    }
                    viewModel.ProductsForOtherCategories.Add(productList);

                }
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}