using Control_V_3.Convert;
using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using DataBase;
using DataBase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.EFRepository
{
    public class EFOrderRepository : IOrderRepository
    {
        ApplicationContext context = new ApplicationContext();
        ICollection<Order> BooksList()
        {
            List<Order> ord = new List<Order>();
            foreach (var x in context.Orders)
            {

                ord.Add(ConvertEntity.ConvertToOrder(x));
            }
            return ord;
        }
        public IEnumerable<Order> Orders => BooksList();
        public void SaveOrder(Order order)
        {
            OrderEnt orderEnt = ConvertEntity.ConvertToOrderEnt(order);
            context.AttachRange(order.Lines.Select(l => l.Book));
            if(order.OrderId==0)
            {
                context.Orders.Add(orderEnt);
            }
            context.SaveChanges();
        }
    }
}
