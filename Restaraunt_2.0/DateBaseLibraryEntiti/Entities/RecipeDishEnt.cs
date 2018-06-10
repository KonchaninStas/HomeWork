using DateBaseLibraryEntiti.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Entities
{
    [Table("RecipeDish")]
    public class RecipeDishEnt : IDbEntities
    {
        [ForeignKey("Dish")]
        public int Id { get; set; }
        public string Recipe { get; set; }
        public DishEnt Dish { get; set; }
        public RecipeDishEnt(string recipe, DishEnt dish)
        {
            Recipe = recipe;
            Dish = dish;
        }
        public RecipeDishEnt()
        {

        }
    }
}
