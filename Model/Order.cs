using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using FireWarehouse.Model;

namespace FireWarehouse.Model
{
    public class Order //Оформление заказа
    {
        public int Id { get; set; }  
        public string AdressDelivery { get; set; } // адрес доставки
        public DateTime OrderDate { get; set; } // дата оформления заказа
        public DateTime DeliveryDate { get; set; } // дата доставки
        public int CustomerId { get; set; } // ID  заказчика 
        public string StatusOrder { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual  DeliveryAndWork DeliveryAndWork { get; set; }

        public virtual ICollection<OrderToProduct> OrdersToProducts { get; set; }

        public override string ToString()
        {
            return AdressDelivery;
        }
    }
}
