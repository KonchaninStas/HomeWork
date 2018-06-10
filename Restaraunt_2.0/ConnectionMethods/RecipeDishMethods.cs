using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;

namespace EntityMethods
{
    static public class RecipeDishMethods
    {
        static public bool AddItem(RecipeDish item)
        {
            return ConnectionToDateBase.Unit.RecipesRepository.AddItem(ConnectionToDateBase.Convert.NewRecipeDishEnt(item));
        }
        static public bool AddItems(IEnumerable<RecipeDish> items)
        {
            List<RecipeDishEnt> recipeDishEnts = new List<RecipeDishEnt>();
            foreach (var x in items)
            {
                recipeDishEnts.Add(ConnectionToDateBase.Convert.NewRecipeDishEnt(x));
            }
            return ConnectionToDateBase.Unit.RecipesRepository.AddItems(recipeDishEnts);
        }
        static public bool ChangeItem(RecipeDish item)
        {
            return ConnectionToDateBase.Unit.RecipesRepository.ChangeItem(ConnectionToDateBase.Convert.NewRecipeDishEnt(item));
        }
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.RecipesRepository.DeleteItem(id);
        }
        static public RecipeDish GetItem(int id)
        {
            RecipeDish recipe = ConnectionToDateBase.Convert.NewRecipeDish(ConnectionToDateBase.Unit.RecipesRepository.GetItem(id));
            return recipe;
        }
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
