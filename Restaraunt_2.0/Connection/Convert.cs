using DateBaseLibraryEntiti.Entities;
using LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionToDateBase
{
    public static class Convert
    {
        public static DishEnt NewDishEnt(Dish dish)
        {
            DishEnt dishEnt = new DishEnt(dish.Name, dish.Weight, dish.Price, NewLayoutEnt(dish.LayoutDish), NewRecipeDishEnt(dish.RecipeDish), dish.Kitchen);
            return dishEnt;
        }
        public static LayoutEnt NewLayoutEnt(Layouts layouts)
        {
            Dictionary<ProductEnt, double> productList = new Dictionary<ProductEnt, double>();
            foreach (var x in layouts.ProductForDish)
            {
                productList.Add(NewProductEnt(x.Key), x.Value);
            }
            LayoutEnt layoutEnt = new LayoutEnt(productList, NewDishEnt(layouts.Dish));
            return layoutEnt;
        }
        public static OrderEnt NewOrderEnt(Orders orders)
        {
            List<DishEnt> dishEnts = new List<DishEnt>();
            foreach (var x in orders.Dishes)
            {
                dishEnts.Add(NewDishEnt(x));

            }
            OrderEnt order = new OrderEnt(dishEnts, orders.TimeOfOrder);
            return order;
        }
        public static ProcurementJournalEnt NewProcurementJournalEnt(ProcurementJournals procurement)
        {
            List<ProductEnt> productEnts = new List<ProductEnt>();
            foreach (var x in procurement.Products)
            {
                productEnts.Add(NewProductEnt(x));

            }
            ProcurementJournalEnt procurementJournal = new ProcurementJournalEnt(productEnts);
            return procurementJournal;
        }
        public static ProductEnt NewProductEnt(Product product)
        {
            ProductEnt productEnt = new ProductEnt(product.Name, product.Weight, NewUnitWeightEnt(product.UnitWeight), product.ShelflifeDate, product.UnitPrice);
            return productEnt;
        }
        public static RecipeDishEnt NewRecipeDishEnt(RecipeDish recipe)
        {
            RecipeDishEnt recipeDishEnt = new RecipeDishEnt(recipe.Recipe, NewDishEnt(recipe.Dish));
            return recipeDishEnt;
        }
        public static UnitWeightEnt NewUnitWeightEnt(UnitWeight unit)
        {
            UnitWeightEnt unitWeightEnt = new UnitWeightEnt(unit.Units);
            return unitWeightEnt;
        }

        public static Dish NewDish(DishEnt dishEnt)
        {
            Dish dishs = new Dish();
            dishs.Id = dishEnt.Id;
            dishs.Name = dishEnt.Name;
            dishs.Weight = dishEnt.Weight;
            dishs.Price = dishEnt.Price;
            dishs.LayoutDish = NewLayouts(dishEnt.LayoutDish);
            dishs.RecipeDish = NewRecipeDish(dishEnt.RecipeDish);
            dishs.Kitchen = dishEnt.Kitchen;
            return dishs;
        }
        public static Layouts NewLayouts(LayoutEnt layoutEnt)
        {
            Layouts layouts = new Layouts();
            layouts.Id = layoutEnt.Id;
            layouts.Dish = NewDish(layoutEnt.Dish);
            Dictionary<Product, double> ProductForDish = new Dictionary<Product, double>();
            foreach (var x in layoutEnt.ProductForDish)
            {
                ProductForDish.Add(NewProduct(x.Key), x.Value);
            }
            layouts.ProductForDish = ProductForDish;
            return layouts;
        }
        public static Orders NewOrders(OrderEnt orderEnt)
        {
            Orders orders = new Orders();
            orders.Id = orderEnt.Id;
            List<Dish> dishes = new List<Dish>();
            foreach (var x in orderEnt.Dishes)
            {
                dishes.Add(NewDish(x));
            }
            orders.Dishes = dishes;
            orders.TimeOfOrder = orderEnt.TimeOfOrder;
            return orders;
        }
        public static ProcurementJournals NewProcurementJournals(ProcurementJournalEnt procurementEnt)
        {
            ProcurementJournals journals = new ProcurementJournals();
            journals.Id = procurementEnt.Id;
            List<Product> products = new List<Product>();
            foreach (var x in procurementEnt.Products)
            {
                products.Add(NewProduct(x));
            }
            return journals;
        }
        public static Product NewProduct(ProductEnt productEnt)
        {
            Product product = new Product();
            product.Id = productEnt.Id;
            product.Name = productEnt.Name;
            product.Weight = productEnt.Weight;
            product.UnitWeight = NewUnitWeight(productEnt.UnitWeight);
            product.ShelflifeDate = productEnt.ShelflifeDate;
            product.UnitPrice = productEnt.UnitPrice;
            product.DeliveryDate = productEnt.DeliveryDate;
            return product;
        }
        public static RecipeDish NewRecipeDish(RecipeDishEnt recipeEnt)
        {
            RecipeDish recipeDish = new RecipeDish();
            recipeDish.Id = recipeEnt.Id;
            recipeDish.Recipe = recipeEnt.Recipe;
            recipeDish.Dish = NewDish(recipeEnt.Dish);
            return recipeDish;
        }
        public static UnitWeight NewUnitWeight(UnitWeightEnt unitEnt)
        {
            UnitWeight unitWeight = new UnitWeight();
            unitWeight.Id = unitEnt.Id;
            unitWeight.Units = unitEnt.Unit;
            return unitWeight;
        }
    }
}
