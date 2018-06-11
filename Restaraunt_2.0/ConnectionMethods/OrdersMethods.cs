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
    static public class OrdersMethods
    {  
        /// <summary>
       /// adding an item to the database
       /// </summary>
       /// <param name="item">Item</param>
       /// <returns>Boolean result</returns>
        static public bool AddItem(Orders item)
        {
            return ConnectionToDateBase.Unit.OrdersRepository.AddItem(ConnectionToDateBase.Convert.NewOrderEnt(item));
        }
        /// <summary>
        /// adding an items to the database
        /// </summary>
        /// <param name="items">Items</param>
        /// <returns>Boolean result</returns>
        static public bool AddItems(IEnumerable<Orders> items)
        {

            List<OrderEnt> orderEnts = new List<OrderEnt>();
            foreach (var x in items)
            {
                orderEnts.Add(ConnectionToDateBase.Convert.NewOrderEnt(x));
            }
            return ConnectionToDateBase.Unit.OrdersRepository.AddItems(orderEnts);
        }
        /// <summary>
        /// The method of searching for an element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool ChangeItem(Orders item)
        {
            return ConnectionToDateBase.Unit.OrdersRepository.ChangeItem(ConnectionToDateBase.Convert.NewOrderEnt(item));
        }
        /// <summary>
        /// The method deleting  element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.OrdersRepository.DeleteItem(id);
        }
        /// <summary>
        /// The method of searching for an element in the database by number
        /// </summary>
        /// <param name="id">ID item</param>
        /// <returns>Item</returns>
        static public Orders GetItem(int id)
        {
            Orders orders = ConnectionToDateBase.Convert.NewOrders(ConnectionToDateBase.Unit.OrdersRepository.GetItem(id));
            return orders;
        }
        /// <summary>
        /// Method for retrieving a collection of items from a database
        /// </summary>
        /// <returns>Сollection of items</returns>
        static public List<Orders> Outpoot()
        {
            List<OrderEnt> orderEnts = ConnectionToDateBase.Unit.OrdersRepository.AllItems.ToList();
            List<Orders> orders = new List<Orders>();
            foreach (var o in orderEnts)
            {
                Orders order = ConnectionToDateBase.Convert.NewOrders(o);
                orders.Add(order);
            }
            return orders;
        }
    }
}
