using ConnectionToDateBase;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMethods
{/// <summary>
/// Methods for performing actions in databases
/// </summary>
    public static class DishMetods
    {
        /// <summary>
        /// adding an item to the database
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool AddItem(Dish item)
        {
            return Unit.DishesRepository.AddItem(ConnectionToDateBase.Convert.NewDishEnt(item));
        }
        /// <summary>
        /// adding an items to the database
        /// </summary>
        /// <param name="items">Items</param>
        /// <returns>Boolean result</returns>
        static public bool AddItems(IEnumerable<Dish> items)
        {
            List<DishEnt> dishEnts = new List<DishEnt>();
            foreach (var x in items)
            {
                dishEnts.Add(ConnectionToDateBase.Convert.NewDishEnt(x));
            }
            return Unit.DishesRepository.AddItems(dishEnts);
        }
        /// <summary>
        /// The method of searching for an element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool ChangeItem(Dish item)
        {
            return Unit.DishesRepository.ChangeItem(ConnectionToDateBase.Convert.NewDishEnt(item));
        }
        /// <summary>
        /// The method deleting  element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool DeleteItem(int id)
        {
            return Unit.DishesRepository.DeleteItem(id);
        } /// <summary>
          /// The method of searching for an element in the database by number
          /// </summary>
          /// <param name="id">ID item</param>
          /// <returns>Item</returns>
        static public Dish GetItem(int id)
        {
            return ConnectionToDateBase.Convert.NewDish(Unit.DishesRepository.GetItem(id));
        }
        /// <summary>
        /// Method for retrieving a collection of items from a database
        /// </summary>
        /// <returns>Сollection of items</returns>
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
