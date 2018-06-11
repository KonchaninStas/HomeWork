using DateBaseLibraryEntiti.Entities;
using LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionToDateBase
{/// <summary>
/// A class that converts elements
/// </summary>
    public static class Convert
    {
        #region Convert to datebase element
        /// <summary>
        /// Creates an item DishEnt
        /// </summary>
        /// <param name="dish">Convertible item Dish</param>
        /// <returns>DishEnt</returns>
        public static DishEnt NewDishEnt(Dish dish)
        {
            DishEnt dishEnt = new DishEnt(dish.Name, dish.Weight, dish.Price, NewLayoutEnt(dish.LayoutDish), NewRecipeDishEnt(dish.RecipeDish), dish.Kitchen);
            return dishEnt;
        }
        /// <summary>
        /// Creates an item  LayoutEnt
        /// </summary>
        /// <param name="layouts">Convertible item Layouts</param>
        /// <returns> LayoutEnt</returns>
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
        /// <summary>
        /// Creates an item  OrderEnt
        /// </summary>
        /// <param name="orders">Convertible item Orders </param>
        /// <returns> OrderEnt</returns>
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
        /// <summary>
        /// Creates an item ProcurementJournalEnt
        /// </summary>
        /// <param name="procurement">Convertible item ProcurementJournals</param>
        /// <returns>ProcurementJournalEnt</returns>
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
        /// <summary>
        /// Creates an item  ProductEnt
        /// </summary>
        /// <param name="product">Convertible item Product</param>
        /// <returns> ProductEnt</returns>
        public static ProductEnt NewProductEnt(Product product)
        {
            ProductEnt productEnt = new ProductEnt(product.Name, product.Weight, NewUnitWeightEnt(product.UnitWeight), product.ShelflifeDate, product.UnitPrice);
            return productEnt;
        }
        /// <summary>
        /// Creates an item RecipeDishEnt
        /// </summary>
        /// <param name="recipe">Convertible item RecipeDish</param>
        /// <returns>RecipeDishEnt</returns>
        public static RecipeDishEnt NewRecipeDishEnt(RecipeDish recipe)
        {
            RecipeDishEnt recipeDishEnt = new RecipeDishEnt(recipe.Recipe, NewDishEnt(recipe.Dish));
            return recipeDishEnt;
        }
        /// <summary>
        /// Creates an item UnitWeightEnt
        /// </summary>
        /// <param name="unit">Convertible item UnitWeight</param>
        /// <returns>UnitWeightEnt</returns>
        public static UnitWeightEnt NewUnitWeightEnt(UnitWeight unit)
        {
            UnitWeightEnt unitWeightEnt = new UnitWeightEnt(unit.Units);
            return unitWeightEnt;
        }
        #endregion
        #region Convert to entity
        /// <summary>
        /// Creates an item Dish
        /// </summary>
        /// <param name="dishEnt">Convertible item DishEnt</param>
        /// <returns>Dish</returns>
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
        /// <summary>
        /// Creates an item Layouts
        /// </summary>
        /// <param name="layoutEnt">Convertible item LayoutEnt</param>
        /// <returns>Layouts</returns>
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
        /// <summary>
        /// Creates an item  Orders 
        /// </summary>
        /// <param name="orderEnt">Convertible item OrderEnt</param>
        /// <returns> Orders </returns>
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
        /// <summary>
        /// Creates an item ProcurementJournals
        /// </summary>
        /// <param name="procurementEnt">Convertible item ProcurementJournalEnt </param>
        /// <returns>ProcurementJournals</returns>
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
        /// <summary>
        /// Creates an item  Product
        /// </summary>
        /// <param name="productEnt">Convertible item ProductEnt</param>
        /// <returns> Product</returns>
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
        /// <summary>
        /// Creates an item RecipeDish
        /// </summary>
        /// <param name="recipeEnt">Convertible item RecipeDishEnt</param>
        /// <returns>RecipeDish</returns>
        public static RecipeDish NewRecipeDish(RecipeDishEnt recipeEnt)
        {
            RecipeDish recipeDish = new RecipeDish();
            recipeDish.Id = recipeEnt.Id;
            recipeDish.Recipe = recipeEnt.Recipe;
            recipeDish.Dish = NewDish(recipeEnt.Dish);
            return recipeDish;
        }
        /// <summary>
        /// Creates an item UnitWeight
        /// </summary>
        /// <param name="unitEnt">Convertible item UnitWeightEnt</param>
        /// <returns>UnitWeight</returns>
        public static UnitWeight NewUnitWeight(UnitWeightEnt unitEnt)
        {
            UnitWeight unitWeight = new UnitWeight();
            unitWeight.Id = unitEnt.Id;
            unitWeight.Units = unitEnt.Unit;
            return unitWeight;
        }
        #endregion
    }
}
