using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.DbContex;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Repositories.GenericRepositories
{
    /// <summary>
    /// Generic methods for item
    /// </summary>
    /// <typeparam name="T">Type item</typeparam>
    public class GenericRepositories<T>:  IDbGenericRepositories<T> where T : class, IDbEntities
    {
        public StoreDbContex context;

        public GenericRepositories(StoreDbContex Contex)
        {
            context = Contex;
        }
        /// <summary>
        /// Вывод всех элементов
        /// </summary>
        public virtual IQueryable<T> AllItems
        {
            get
            {
                return context.Set<T>();
            }
        }
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое знаение</returns>
        public bool AddItem(T item)
        {
            context.Set<T>().Add(item);
            return SaveChanges();
        }
        /// <summary>
        /// Добавление масива элементов
        /// </summary>
        /// <param name="items">Элемент</param>
        /// <returns>Логическое знаение</returns>
        public bool AddItems(IEnumerable<T> items)
        {
            context.Set<T>().AddRange(items);
            return SaveChanges();
        }
        /// <summary>
        /// Найден ли элемент и если найден сохраняет новый по ID
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        public bool ChangeItem(T item)
        {
            T chang = GetItem(item.Id);
            if (chang == null)
                return false;
            else
                chang = item;
            return SaveChanges();
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Логическое знаение</returns>
        public bool DeleteItem(int id)
        {
            T item = GetItem(id);
            if (item == null)
                return false;
            else
                context.Set<T>().Remove(item);
            return SaveChanges();

        }
        /// <summary>
        /// Получение элемента по ID
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Элемент</returns>
        public  T GetItem(int id)
        {
            return AllItems.FirstOrDefault(x => x.Id.Equals(id));

        }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns>Логическое знаение</returns>
        public bool SaveChanges()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
