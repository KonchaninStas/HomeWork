using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;

namespace EntityMethods
{/// <summary>
/// Methods for performing actions in databases
/// </summary>
    static public class RecipeDishMethods
    {  /// <summary>
       /// adding an item to the database
       /// </summary>
       /// <param name="item">Item</param>
       /// <returns>Boolean result</returns>
        static public bool AddItem(RecipeDish item)
        {
            return ConnectionToDateBase.Unit.RecipesRepository.AddItem(ConnectionToDateBase.Convert.NewRecipeDishEnt(item));
        }
        /// <summary>
        /// adding an items to the database
        /// </summary>
        /// <param name="items">Items</param>
        /// <returns>Boolean result</returns>
        static public bool AddItems(IEnumerable<RecipeDish> items)
        {
            List<RecipeDishEnt> recipeDishEnts = new List<RecipeDishEnt>();
            foreach (var x in items)
            {
                recipeDishEnts.Add(ConnectionToDateBase.Convert.NewRecipeDishEnt(x));
            }
            return ConnectionToDateBase.Unit.RecipesRepository.AddItems(recipeDishEnts);
        }
        /// <summary>
        /// The method of searching for an element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool ChangeItem(RecipeDish item)
        {
            return ConnectionToDateBase.Unit.RecipesRepository.ChangeItem(ConnectionToDateBase.Convert.NewRecipeDishEnt(item));
        }
        /// <summary>
        /// The method deleting  element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.RecipesRepository.DeleteItem(id);
        }
        /// <summary>
        /// The method of searching for an element in the database by number
        /// </summary>
        /// <param name="id">ID item</param>
        /// <returns>Item</returns>
        static public RecipeDish GetItem(int id)
        {
            RecipeDish recipe = ConnectionToDateBase.Convert.NewRecipeDish(ConnectionToDateBase.Unit.RecipesRepository.GetItem(id));
            return recipe;
        }
        /// <summary>
        /// Method for retrieving a collection of items from a database
        /// </summary>
        /// <returns>Сollection of items</returns>
        static public List<RecipeDish> Outpoot()
        {
            List<RecipeDishEnt> recipeDishEnts = ConnectionToDateBase.Unit.RecipesRepository.AllItems.ToList();
            List<RecipeDish> recipes = new List<RecipeDish>();
            foreach (var x in recipeDishEnts)
            {
                RecipeDish recipe = ConnectionToDateBase.Convert.NewRecipeDish(x);
                recipes.Add(recipe);
            }
            return recipes;
        }
    }
}
