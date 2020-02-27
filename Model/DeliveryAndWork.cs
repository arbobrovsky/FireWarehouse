using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarehouse.Model
{
    public class DeliveryAndWork
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string DriverFIO { get; set; }
        public string DeliveryMethod { get; set; }
        public string Typeofwork { get; set; }
        public string Worker1 { get; set; }
        public string Worker2 { get; set; }
        public string Worker3 { get; set; }
        public string Worker4 { get; set; }
        public string Worker5 { get; set; }
    }
}
