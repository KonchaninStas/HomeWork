using EntityBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDb;

namespace Methods
{
    public class RecipeDish
    {
        public int Id { get; set; }
        public string Recipe { get; set; }
        public Dish Dish { get; set; }

        public RecipeDish(RecipeDishEnt recipe)
        {
            Id = recipe.Id;
            Recipe = recipe.Recipe;
            Dish = new Dish(recipe.Dish);
        }
        public RecipeDish(int id, string recipe, Dish dish)
        {
            Recipe = recipe;
            Dish = dish;
        }

        void AddRecipe(string recipe, DishEnt dish)
        {
            RecipeDishEnt recipeForDish = new RecipeDishEnt(recipe, dish);
            Unit.RecipesRepository.AddItem(recipeForDish);
        }
        void DeleteRecipe(int id)
        {
            Unit.RecipesRepository.DeleteItem(id);
        }
        List<RecipeDish> DishesOutpoot()
        {

            List<RecipeDishEnt> recipeDishEnts = Unit.RecipesRepository.AllItems.ToList();
            List<RecipeDish> recipeDishes = new List<RecipeDish>();
            foreach (var p in recipeDishEnts)
            {
                Dish dish = new Dish(p.Dish.Id, p.Dish.Name, p.Dish.Weight, p.Dish.Price, new Layots(p.Dish.LayoutDish), new RecipeDish(p.Dish.RecipeDish), p.Dish.Kitchen);
                RecipeDish recipe = new RecipeDish(p.Id, p.Recipe, new Dish(p.Dish));
                recipeDishes.Add(recipe);
            }
            return recipeDishes;
        }
    }
}
