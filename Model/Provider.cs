using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarehouse.Model
{
    public class Provider  //Поставщики продуктов
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Legaladdress { get; set; }
        public DateTime dateProviderProduct { get; set; }

        public override string ToString()
        {
            return FIO;
        }
    }
}
