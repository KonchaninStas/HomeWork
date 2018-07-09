using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Entity
{
   public class CartLineEnt
    {
        public int CartLineEntId { get; set; }
        public BookEnt Book { get; set; }
        public int Quantity { get; set; }
        public CartLineEnt()
        {

        }
    }
}
