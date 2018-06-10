using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class Orders : Entities
    {
        public List<Dish> Dishes { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public Orders()
        {
        }
    }
}
