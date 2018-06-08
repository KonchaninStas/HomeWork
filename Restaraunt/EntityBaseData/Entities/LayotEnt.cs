using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData.Entities
{
    public class LayoutEnt : DbEntity
    {
        public virtual Dictionary<ProductEnt, decimal> ProductForDish { get; set; }
        public virtual DishEnt Dish { get; set; }
        public LayoutEnt(Dictionary<ProductEnt, decimal> productForDish, DishEnt dish)
        {
            ProductForDish = productForDish;
            Dish = dish;
        }
        public LayoutEnt()
        {
            ProductForDish = new Dictionary<ProductEnt, decimal>();
        }
    }
}

