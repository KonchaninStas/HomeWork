using DateBaseLibraryEntiti.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Entities
{
    [Table("Order")]
    public class OrderEnt : DbEntity
    {
        public virtual List<DishEnt> Dishes { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public OrderEnt()
        {
            Dishes = new List<DishEnt>();
        }
        public OrderEnt(List<DishEnt> dishes, DateTime time)
        {
            Dishes = dishes;
            TimeOfOrder = time;
        }
    }
}
