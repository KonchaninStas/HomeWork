using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public User User { get; set; }
        public List<Book> Books { get; set; }
    }
}
