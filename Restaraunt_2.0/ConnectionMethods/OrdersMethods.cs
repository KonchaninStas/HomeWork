using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;

namespace EntityMethods
{
    static public class OrdersMethods
    {
        static public bool AddItem(Orders item)
        {
            return ConnectionToDateBase.Unit.OrdersRepository.AddItem(ConnectionToDateBase.Convert.NewOrderEnt(item));
        }
        static public bool AddItems(IEnumerable<Orders> items)
        {

            List<OrderEnt> orderEnts = new List<OrderEnt>();
            foreach (var x in items)
            {
                orderEnts.Add(ConnectionToDateBase.Convert.NewOrderEnt(x));
            }
            return ConnectionToDateBase.Unit.OrdersRepository.AddItems(orderEnts);
        }
        static public bool ChangeItem(Orders item)
        {
            return ConnectionToDateBase.Unit.OrdersRepository.ChangeItem(ConnectionToDateBase.Convert.NewOrderEnt(item));
        }
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.OrdersRepository.DeleteItem(id);
        }
        static public Orders GetItem(int id)
        {
            Orders orders = ConnectionToDateBase.Convert.NewOrders(ConnectionToDateBase.Unit.OrdersRepository.GetItem(id));
            return orders;
        }
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
