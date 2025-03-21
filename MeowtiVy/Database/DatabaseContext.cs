using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;
using System.Data.Entity;  

namespace MeowtiVy.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=LocalDbPsd")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}