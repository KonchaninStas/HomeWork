using DateBaseLibraryEntiti.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Entities
{
    [Table("Layout")]
    public class LayoutEnt : IDbEntities
    {
        [ForeignKey("Dish")]
        public int Id { get; set; }
        public virtual Dictionary<ProductEnt, double> ProductForDish { get; set; }
        public DishEnt Dish { get; set; }
        public LayoutEnt(Dictionary<ProductEnt, double> productForDish, DishEnt dish)
        {
            ProductForDish = productForDish;
            Dish = dish;
        }
        public LayoutEnt()
        {
            ProductForDish = new Dictionary<ProductEnt, double>();
        }
    }
}
