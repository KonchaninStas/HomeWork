using ConnectionToDateBase;
using Convert;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities;

namespace EntityMethods
{
    /// <summary>
    /// Методы для работы c категориями
    /// </summary>
    public static class CategoryMethods
    {
        /// <summary>
        /// Добавить новый элемент
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItem(Category item)
        {
            return Unit.CategoryRepository.AddItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Добавить массив элементов
        /// </summary>
        /// <param name="items">массив элементов</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItems(IEnumerable<Category> items)
        {
            List<CategoryEnt> clients = new List<CategoryEnt>();
            foreach (var item in items)
            {
                clients.Add(ConvertEntity.Convert(item));
            }
            return Unit.CategoryRepository.AddItems(clients);
        }
        /// <summary>
        /// Поиск элемента по ID и изменяет его
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool ChangeItem(Category item)
        {
            return Unit.CategoryRepository.ChangeItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Логическое значение</returns>
        static public bool DeleteItem(int id)
        {
            return Unit.CategoryRepository.DeleteItem(id);
        }
        /// <summary>
        /// Получение элемента по индексу
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Элемент</returns>
        static public Category GetItem(int id)
        {
            return ConvertEntity.Convert(Unit.CategoryRepository.GetItem(id));
        }
        /// <summary>
        /// Лист всех элементов
        /// </summary>
        /// <returns>Лист всех элементов</returns>
        static public IEnumerable<Category> Outpoot()
        {
            List<CategoryEnt> list = Unit.CategoryRepository.AllItems.ToList();
            List<Category> clients = new List<Category>();
            foreach (var item in list)
            {
                clients.Add(ConvertEntity.Convert(item));
            }
            return clients;
        }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns>Логическое значение</returns>
        static public bool SaveChanges()
        {
            return Unit.CategoryRepository.SaveChanges();
        }
    }
}
