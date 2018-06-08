using EntityBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDb;

namespace Methods
{
    public class Orders
    {
        public int Id { get; set; }
        public List<Dish> Dishes { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public Orders(OrderEnt order)
        {
            Id = order.Id;
            foreach (var x in order.Dishes)
            {
                Dishes.Add(new Dish(x));
            }
            TimeOfOrder = order.TimeOfOrder;
        }
        void AddOrders(List<DishEnt> Dishe)
        {
            OrderEnt ord = new OrderEnt(Dishe);
            Unit.OrdersRepository.AddItem(ord);
        }
        void OrdersDelete(int id)
        {
            Unit.OrdersRepository.DeleteItem(id);
        }
        List<Orders> OrdersOutpoot()
        {

            List<OrderEnt> orderEnts = Unit.OrdersRepository.AllItems.ToList();
            List<Orders> ordersList = new List<Orders>();
            foreach (var o in orderEnts)
            {
                Orders orders = new Orders(o);
                ordersList.Add(orders);
            }
            return ordersList;
        }
    }
}
