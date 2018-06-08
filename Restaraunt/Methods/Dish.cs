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
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public Layots LayoutDish { get; set; }
        public RecipeDish RecipeDish { get; set; }
        public string Kitchen { get; set; }

        public Dish(int id, string name, decimal weight, decimal price, Layots layot, RecipeDish recipe, string kitchen)
        {
            Name = name;
            Weight = weight;
            Price = price;
            LayoutDish = layot;
            RecipeDish = recipe;
            Kitchen = kitchen;
        }
        public Dish(DishEnt dish)
        {
            Id = dish.Id;
            Name = dish.Name;
            Weight = dish.Weight;
            Price = dish.Price;
            LayoutDish = new Layots(dish.LayoutDish);
            RecipeDish = new RecipeDish(dish.RecipeDish);
            Kitchen = dish.Kitchen;
        }
        void AddDish(string name, decimal weight, decimal price, LayoutEnt layot, RecipeDishEnt recipe, string kitchen)
        {
            DishEnt dish = new DishEnt(name, weight, price, layot, recipe, kitchen);
            Unit.DishesRepository.AddItem(dish);
        }
        void DeleteDish(int id)
        {
            Unit.DishesRepository.DeleteItem(id);
        }
        List<Dish> DishesOutpoot()
        {
            List<DishEnt> dishEnts = Unit.DishesRepository.AllItems.ToList();
            List<Dish> dishes = new List<Dish>();
            foreach (var d in dishEnts)
            {
                Dish dish = new Dish(d);
                dishes.Add(dish);
            }
            return dishes;

        }
    }
}
