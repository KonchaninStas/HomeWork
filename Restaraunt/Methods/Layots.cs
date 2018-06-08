using EntityBaseData;
using EntityBaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDb;

namespace Methods
{
    public class Layots
    {
        int Id { get; set; }
        public Dictionary<Product, decimal> ProductForDish { get; set; }
        public DishEnt Dish { get; set; }
        public Layots(LayoutEnt layoutEnt)
        {
            Id = layoutEnt.Id;
            foreach (var x in layoutEnt.ProductForDish)
            {
                ProductForDish.Add(new Product(x.Key), x.Value);
            }
            Dish = layoutEnt.Dish;
        }

        void AddLayots(Dictionary<ProductEnt, decimal> productForDish, DishEnt dish)
        {
            LayoutEnt layot = new LayoutEnt(productForDish, dish);
            Unit.LayotsRepository.AddItem(layot);
        }
        void DeleteLayot(int id)
        {
            Unit.LayotsRepository.DeleteItem(id);
        }
        List<Layots> LayotOutpoot()
        {

            List<LayoutEnt> layoutEnts = Unit.LayotsRepository.AllItems.ToList();
            List<Layots> layotsList = new List<Layots>();
            foreach (var l in layoutEnts)
            {
                Layots layots = new Layots(l);
                layotsList.Add(layots);
            }
            return layotsList;
        }
    }
}
