using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarehouse.Model
{
   public class User // пользователь
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Prioritet { get; set; }

        public override string ToString()
        {
            return Login;
        }

    }
}
