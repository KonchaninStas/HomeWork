using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Entity
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public CartLine()
        {

        }
    }
    
}
