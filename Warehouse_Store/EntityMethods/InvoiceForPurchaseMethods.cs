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
    /// Методы для работы c накладной закупок
    /// </summary>
    public static class InvoiceForPurchaseMethods
    {
        /// <summary>
        /// Добавить новый элемент
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItem(InvoiceForPurchase item)
        {
            return Unit.InvoiceForPurchaseRepository.AddItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Добавить массив элементов
        /// </summary>
        /// <param name="items">массив элементов</param>
        /// <returns>Логическое значение</returns>
        static public bool AddItems(IEnumerable<InvoiceForPurchase> items)
        {
            List<InvoiceForPurchaseEnt> clients = new List<InvoiceForPurchaseEnt>();
            foreach (var item in items)
            {
                clients.Add(ConvertEntity.Convert(item));
            }
            return Unit.InvoiceForPurchaseRepository.AddItems(clients);
        }
        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Логическое значение</returns>
        static public bool ChangeItem(InvoiceForPurchase item)
        {
            return Unit.InvoiceForPurchaseRepository.ChangeItem(ConvertEntity.Convert(item));
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Логическое значение</returns>
        static public bool DeleteItem(int id)
        {
            return Unit.InvoiceForPurchaseRepository.DeleteItem(id);
        }
        /// <summary>
        /// Получение элемента по индексу
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Элемент</returns>
        static public InvoiceForPurchase GetItem(int id)
        {
            return ConvertEntity.Convert(Unit.InvoiceForPurchaseRepository.GetItem(id));
        }
        /// <summary>
        /// Лист всех элементов
        /// </summary>
        /// <returns>Лист всех элементов</returns>
        static public IEnumerable<InvoiceForPurchase> Outpoot()
        {
            List<InvoiceForPurchaseEnt> list = Unit.InvoiceForPurchaseRepository.AllItems.ToList();
            List<InvoiceForPurchase> clients = new List<InvoiceForPurchase>();
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
            return Unit.InvoiceForPurchaseRepository.SaveChanges();
        }
    }
}
