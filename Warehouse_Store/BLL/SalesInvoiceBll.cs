using Entities;
using EntityMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Работа с накладными продаж
    /// </summary>
    public static class SalesInvoiceBll
    {
        /// <summary>
        /// Поиск накладных продаж по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Список накладных продаж</returns>
        public static IEnumerable<SalesInvoice> SalesInvoices(DateTime date)
        {
            var x = from m in SalesInvoiceMethods.Outpoot() where m.Date.Value.Date == date.Date select m;
            return x;
        }
        /// <summary>
        /// Поиск накладных продаж за период
        /// </summary>
        /// <param name="firstDate">Дата начало периода</param>
        /// <param name="lastDate">Дата конца периода</param>
        /// <returns>Список накладных продаж</returns>
        public static IEnumerable<SalesInvoice> SalesInvoices(DateTime firstDate, DateTime lastDate)
        {
            var x = from m in SalesInvoiceMethods.Outpoot()
                    where (m.Date.Value.Date >= firstDate.Date && m.Date.Value.Date <= lastDate.Date)
                    select m;
            return x;
        }
        /// <summary>
        /// Общая стоимость
        /// </summary>
        /// <param name="sales">Накладная</param>
        /// <returns>Общая стоимость</returns>
        public static decimal TotalPrice(SalesInvoice sales)
        {
            decimal price=0;
            foreach (var item in sales.Product)
            {
                price =price+ item.Price;
            }
            return price;
        }
    }
}
