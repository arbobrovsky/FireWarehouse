using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarehouse.Model
{
    public class OrderToProduct 
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Measure { get; set; } //Еденица измерения
        public float CountProduct { get; set; }
        public decimal Price { get; set; }
         
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
//string.Format("{0} {1}", CountProduct, Price);