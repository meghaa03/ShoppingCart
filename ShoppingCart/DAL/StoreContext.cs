using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ShoppingCart.DAL
{
    public class StoreContext: DbContext
    {
        public StoreContext() : base("StoreContext")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ShoppingCart.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ShoppingCart.Models.Cart> Carts { get; set; }
    }
}