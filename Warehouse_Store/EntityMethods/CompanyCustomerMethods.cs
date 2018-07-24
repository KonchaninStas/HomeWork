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
    /// Методы для работы клиентами компаниями
    /// </summary>
   public static class CompanyCustomerMethods
    {
        /// <summary>
        /// Добавить новый элемент
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItem(CompanyCustomer item)
        {
            return Unit.CompanyСustomerRepository.AddItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Добавить массив элементов
        /// </summary>
        /// <param name="items">массив элементов</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItems(IEnumerable<CompanyCustomer> items)
        {
            List<CompanyCustomerEnt> clients = new List<CompanyCustomerEnt>();
            foreach (var item in items)
            {
                clients.Add(ConvertEntity.Convert(item));
            }
            return Unit.CompanyСustomerRepository.AddItems(clients);
        }
        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool ChangeItem(CompanyCustomer item)
        {
            return Unit.CompanyСustomerRepository.ChangeItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Логическое значение</returns>
        static public bool DeleteItem(int id)
        {
            return Unit.CompanyСustomerRepository.DeleteItem(id);
        }
        /// <summary>
        /// Получение элемента по индексу
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Элемент</returns>
        static public CompanyCustomer GetItem(int id)
        {
            return ConvertEntity.Convert(Unit.CompanyСustomerRepository.GetItem(id));
        }
        /// <summary>
        /// Лист всех элементов
        /// </summary>
        /// <returns>Лист всех элементов</returns>
        static public IEnumerable<CompanyCustomer> Outpoot()
        {
            List<CompanyCustomerEnt> list = Unit.CompanyСustomerRepository.AllItems.ToList();
            List<CompanyCustomer> clients = new List<CompanyCustomer>();
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
            return Unit.CompanyСustomerRepository.SaveChanges();
        }
    }
}
