using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarehouse.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FIOClient { get; set; }
        public string PasportData { get; set; }
        public string Sity { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreateOnCustomer { get; set; }

        public override string ToString()
        {
            return FIOClient;
        }
    }
}
