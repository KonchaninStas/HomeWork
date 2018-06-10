using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class RecipeDish : Entities
    {
        public string Recipe { get; set; }
        public Dish Dish { get; set; }

        public RecipeDish()
        {
        }
        public RecipeDish( string recipe, Dish dish)
        {
            Recipe = recipe;
            Dish = dish;
        }
    }
}
