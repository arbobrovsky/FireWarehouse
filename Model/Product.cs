using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarehouse.Model
{
    public class Product // Продукт 
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int UserId { get; set; }
        public string NameProduct { get; set; }
        public string NameFirma { get; set; }
        public float CountProductOnStorehome { get; set; }
        public string Measure { get; set; } //еденица измерение
        public decimal PriceProduct { get; set; }
        public string InformationProduct { get; set; }
        public string Images { get; set; }
        public string ImageScheme { get; set; }
        

        public DateTime ReceiptDate { get; set; }
        public DateTime CreateOn { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual  User User { get; set; }

        public override string ToString()
        {
            return NameProduct;
        }

    }
}
