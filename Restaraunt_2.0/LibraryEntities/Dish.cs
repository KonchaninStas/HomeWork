using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class Dish : Entities
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public Layouts LayoutDish { get; set; }
        public RecipeDish RecipeDish { get; set; }
        public string Kitchen { get; set; }
        public Dish()
        {

        }

        public Dish(string name, double weight, double price, Layouts layot, RecipeDish recipe, string kitchen)
        {
            Name = name;
            Weight = weight;
            Price = price;
            LayoutDish = layot;
            RecipeDish = recipe;
            Kitchen = kitchen;
        }
    }
}

