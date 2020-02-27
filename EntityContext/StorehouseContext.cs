using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FireWarehouse.Model;
namespace FireWarehouse.EntityContext
{
    public class StorehouseContext : DbContext
    {
        public StorehouseContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<OrderToProduct> OrdersToProducts { get; set; }
        public DbSet<DeliveryAndWork> DeliverysAndWorks { get; set; }
       

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
