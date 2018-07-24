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
    /// Методы для работы c накладной продаж
    /// </summary>
    public static class SalesInvoiceMethods
    {
        /// <summary>
        /// Добавить новый элемент
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItem(SalesInvoice item)
        {
            return Unit.SalesInvoiceRepository.AddItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Добавить массив элементов
        /// </summary>
        /// <param name="items">массив элементов</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItems(IEnumerable<SalesInvoice> items)
        {
            List<SalesInvoiceEnt> clients = new List<SalesInvoiceEnt>();
            foreach (var item in items)
            {
                clients.Add(ConvertEntity.Convert(item));
            }
            return Unit.SalesInvoiceRepository.AddItems(clients);
        }
        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool ChangeItem(SalesInvoice item)
        {
            return Unit.SalesInvoiceRepository.ChangeItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Логическое значение</returns>
        static public bool DeleteItem(int id)
        {
            return Unit.SalesInvoiceRepository.DeleteItem(id);
        }
        /// <summary>
        /// Получение элемента по индексу
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Элемент</returns>
        static public SalesInvoice GetItem(int id)
        {
            return ConvertEntity.Convert(Unit.SalesInvoiceRepository.GetItem(id));
        }
        /// <summary>
        /// Лист всех элементов
        /// </summary>
        /// <returns>Лист всех элементов</returns>
        static public IEnumerable<SalesInvoice> Outpoot()
        {
            List<SalesInvoiceEnt> list = Unit.SalesInvoiceRepository.AllItems.ToList();
            List<SalesInvoice> clients = new List<SalesInvoice>();
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
            return Unit.SalesInvoiceRepository.SaveChanges();
        }
    }
}
