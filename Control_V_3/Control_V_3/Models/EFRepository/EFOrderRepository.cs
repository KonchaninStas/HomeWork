using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.EFRepository
{
    public class EFOrderRepository : IOrderRepository
    {
        ApplicationContext context = new ApplicationContext();
        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Book);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Book));
            if(order.OrderId==0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
