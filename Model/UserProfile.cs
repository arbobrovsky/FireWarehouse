using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FireWarehouse.Model
{
   public class UserProfile // Пользователь (информация о нем)(Связь один к одному )
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public int UserId { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public User User { get; set; }
    }
}
