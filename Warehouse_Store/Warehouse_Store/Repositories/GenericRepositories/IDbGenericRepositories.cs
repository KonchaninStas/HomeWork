using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Repositories.GenericRepositories
{
    public interface IDbGenericRepositories<T> where T : class, IDbEntities
    {
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AddItem(T item);
        /// <summary>
        /// Добавление масива элементов
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        bool AddItems(IEnumerable<T> items);
        /// <summary>
        /// Вывод всех элементов
        /// </summary>
        IQueryable<T> AllItems { get; }
        /// <summary>
        /// Найден ли элемент
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Логическое значение</returns>
        bool ChangeItem(T item);
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteItem(int id);
        /// <summary>
        /// Получение элемента по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItem(int id);
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
