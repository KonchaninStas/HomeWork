using DateBaseLibraryEntiti.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Entities
{
    [Table("Dish")]
    public class DishEnt : DbEntity
    {
        [StringLength(64)]
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public LayoutEnt LayoutDish { get; set; }
        public RecipeDishEnt RecipeDish { get; set; }
        public string Kitchen { get; set; }
        public DishEnt()
        {
        }
        public DishEnt(string name, double weight, double price, LayoutEnt layot, RecipeDishEnt recipe, string kitchen)
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
