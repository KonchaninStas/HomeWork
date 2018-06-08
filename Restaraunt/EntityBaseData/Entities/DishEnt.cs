using EntityBaseData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    [Table("Dish")]
    public class DishEnt:DbEntity
    {
       
        [StringLength(64)]
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public virtual LayoutEnt LayoutDish { get; set; }
        public virtual RecipeDishEnt RecipeDish { get; set; }
        public string Kitchen { get; set; }

        public DishEnt(string name, decimal weight, decimal price, LayoutEnt layot, RecipeDishEnt recipe, string kitchen)
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
