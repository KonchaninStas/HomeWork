using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    [Table("RecipeDish")]
    public  class RecipeDishEnt : DbEntity
    {
       
        public string Recipe { get; set; }//рецепт
        public virtual DishEnt Dish { get; set; }//блюдо

        public RecipeDishEnt(string recipe, DishEnt dish)
        {
            Recipe = recipe;
            Dish = dish;
        }
    }
}
