using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireWarehouse.Model;
using FireWarehouse.EntityContext;
using System.Data.Entity;
namespace FireWarehouse.Controller
{
    public class Controller
    {
        
        public static async Task<IList<Product>> getProductAsync()
        {
            StorehouseContext db = new StorehouseContext();
            var result = ReadProduct(db);

            return await Task.FromResult(result);
        }

        private static IList<Product> ReadProduct(StorehouseContext db)
        {
            db.Products.Load();
            var result = db.Products.Local.ToBindingList();
            if (result == null) return result;

            return result;
        }

        public static async Task<IList<User>> getUserAsync()
        {
            StorehouseContext db = new StorehouseContext();
            var result = ReadUsers(db);

            return await Task.FromResult(result);
        }

        private static IList<User> ReadUsers(StorehouseContext db)
        {
            db.Users.Load();
            var result = db.Users.Local.ToBindingList();
            if (result == null) return result;

            return result;
        }

        public static async Task<IList<Customer>> getCustomerAsync()
        {
            StorehouseContext db = new StorehouseContext();
            var result = ReadCustomer(db);

            return await Task.FromResult(result);
        }

        private static IList<Customer> ReadCustomer(StorehouseContext db)
        {
            db.Customers.Load();
            var result = db.Customers.Local.ToBindingList();
            if (result == null) return result;

            return result;
        }

        public static async Task<IList<Order>> getOrderAsync()
        {
            StorehouseContext db = new StorehouseContext();
            var result = ReadOrder(db);

            return await Task.FromResult(result);
        }

        private static IList<Order> ReadOrder(StorehouseContext db)
        {
            db.Orders.Load();
            var result = db.Orders.Local.ToBindingList();
            if (result == null) return result;

            return result;
        }


        public static async Task<IList<OrderToProduct>> getOrderToProductAsync()
        {
            StorehouseContext db = new StorehouseContext();
            var result = OrderToProduct(db);

            return await Task.FromResult(result);
        }

        private static IList<OrderToProduct> OrderToProduct(StorehouseContext db)
        {
            db.OrdersToProducts.Load();
            var result = db.OrdersToProducts.Local.ToBindingList();
            if (result == null) return result;

            return result;
        }


    }
}