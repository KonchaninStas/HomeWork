using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData.Repositories
{
   public class GenericRepositories<T> :IDbRepositories<T> where T:class,IDbEntities
    {
        private RestorauntDbContex context;

        public GenericRepositories(RestorauntDbContex Contex)
        {
            context = Contex;
        }
        public IQueryable<T> AllItems
        {
            get
            {
                return context.Set<T>();
            }
        }


        public bool AddItem(T item)
        {
            context.Set<T>().Add(item);
            return SaveChanges();
        }

        public bool AddItems(IEnumerable<T> items)
        {
            context.Set<T>().AddRange(items);
            return SaveChanges();
        }

        public bool ChangeItem(T item)
        {
            T chang = GetItem(item.Id);
            if (chang == null)
                return false;
            else
                chang = item;
            return SaveChanges();
        }

        public bool DeleteItem(int id)
        {
            T item = GetItem(id);
            if (item == null)
                return false;
            else
                context.Set<T>().Remove(item);
            return SaveChanges();

        }

        public T GetItem(int id)
        {
            return AllItems.FirstOrDefault(x => x.Id.Equals(id));

        }

        public bool SaveChanges()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
