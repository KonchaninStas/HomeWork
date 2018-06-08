using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    [Table("Order")]
    public class OrderEnt : DbEntity
    {
        public virtual List<DishEnt> Dishes { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public OrderEnt()
        {
        }
         public OrderEnt(List<DishEnt> Dishes)
        {
            TimeOfOrder = DateTime.Now;
        }


    }
}
