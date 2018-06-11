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
    static public class ProductMethods
    {  /// <summary>
       /// adding an item to the database
       /// </summary>
       /// <param name="item">Item</param>
       /// <returns>Boolean result</returns>
        static public bool AddItem(Product item)
        {
            return ConnectionToDateBase.Unit.ProductsRepository.AddItem(ConnectionToDateBase.Convert.NewProductEnt(item));
        }
        /// <summary>
        /// adding an items to the database
        /// </summary>
        /// <param name="items">Items</param>
        /// <returns>Boolean result</returns>
        static public bool AddItems(IEnumerable<Product> items)
        {
            List<ProductEnt> productEnts= new List<ProductEnt>();
            foreach (var x in items)
            {
                productEnts.Add(ConnectionToDateBase.Convert.NewProductEnt(x));
            }
            return ConnectionToDateBase.Unit.ProductsRepository.AddItems(productEnts);
        }
        /// <summary>
        /// The method of searching for an element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool ChangeItem(Product item)
        {
            return ConnectionToDateBase.Unit.ProductsRepository.ChangeItem(ConnectionToDateBase.Convert.NewProductEnt(item));
        }
        /// <summary>
        /// The method deleting  element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.ProductsRepository.DeleteItem(id);
        }
        /// <summary>
        /// The method of searching for an element in the database by number
        /// </summary>
        /// <param name="id">ID item</param>
        /// <returns>Item</returns>
        static public Product GetItem(int id)
        {
            Product product = ConnectionToDateBase.Convert.NewProduct(ConnectionToDateBase.Unit.ProductsRepository.GetItem(id));
            return product;
        }
        /// <summary>
        /// Method for retrieving a collection of items from a database
        /// </summary>
        /// <returns>Сollection of items</returns>
        static public List<Product> Outpoot()
        {
            List<ProductEnt> productEnts = ConnectionToDateBase.Unit.ProductsRepository.AllItems.ToList();
            List<Product> products = new List<Product>();
            foreach (var p in productEnts)
            {
              Product product = ConnectionToDateBase.Convert.NewProduct(p);
               products.Add(product);
            }
            return products;
        }
    }
}
