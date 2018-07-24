using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMethods
{
   interface IMethodsEntity<T> where T : class, IEntities
    {
        bool AddItem(T item);
        bool AddItems(IEnumerable<T> items);
        bool ChangeItem(T item);
        bool DeleteItem(int id);
        T GetItem(int id);
        List<T> Outpoot();
    }
}
