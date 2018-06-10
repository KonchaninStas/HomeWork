using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class Layouts : Entities
    {
        public Dictionary<Product, double> ProductForDish { get; set; }
        public Dish Dish { get; set; }
        public Layouts()
        {

        }
    }
}
