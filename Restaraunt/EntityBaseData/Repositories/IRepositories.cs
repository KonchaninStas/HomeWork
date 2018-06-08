using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData.Repositories
{
   public interface IDbRepositories<T> where T:class,IDbEntities
    {
        bool AddItem(T item);
        bool AddItems(IEnumerable<T> items);
        IQueryable<T> AllItems { get; }
        bool ChangeItem(T item);
        bool DeleteItem(int id);
        T GetItem(int id);
        bool SaveChanges();
    }
}
