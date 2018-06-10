using ConnectionToDateBase;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMethods
{
    public static class DishMetods
    {
        static public bool AddItem(Dish item)
        {
            return Unit.DishesRepository.AddItem(ConnectionToDateBase.Convert.NewDishEnt(item));
        }
        static public bool AddItems(IEnumerable<Dish> items)
        {
            List<DishEnt> dishEnts = new List<DishEnt>();
            foreach (var x in items)
            {
                dishEnts.Add(ConnectionToDateBase.Convert.NewDishEnt(x));
            }
            return Unit.DishesRepository.AddItems(dishEnts);
        }
        static public bool ChangeItem(Dish item)
        {
            return Unit.DishesRepository.ChangeItem(ConnectionToDateBase.Convert.NewDishEnt(item));
        }
        static public bool DeleteItem(int id)
        {
            return Unit.DishesRepository.DeleteItem(id);
        }
        static public Dish GetItem(int id)
        {
            return ConnectionToDateBase.Convert.NewDish(Unit.DishesRepository.GetItem(id));
        }
        static public List<Dish> Outpoot()
        {
            List<DishEnt> dishEnts = Unit.DishesRepository.AllItems.ToList();
            List<Dish> dishes = new List<Dish>();
            foreach (var d in dishEnts)
            {
                Dish dish = ConnectionToDateBase.Convert.NewDish(d);
                dishes.Add(dish);
            }
            return dishes;
        }
    }
}
