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
    /// Работа с накладными закупок
    /// </summary>
  public static class InvoiceForPurchasesBll
    {
        /// <summary>
        /// Поиск накладных закупок по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Список накладных закупок</returns>
        public static IEnumerable<InvoiceForPurchase> InvoiceForPurchases(DateTime date)
        {
            var x = from m in InvoiceForPurchaseMethods.Outpoot() where m.Date == date.Date select m;
            return x;
        }
        /// <summary>
        /// Поиск накладных закупок за период
        /// </summary>
        /// <param name="firstDate">Дата начало периода </param>
        /// <param name="lastDate">Дата конца периода</param>
        /// <returns></returns>
        public static IEnumerable<InvoiceForPurchase> InvoiceForPurchases(DateTime firstDate, DateTime lastDate)
        {
            var x = from m in InvoiceForPurchaseMethods.Outpoot()
                    where (m.Date >= firstDate.Date && m.Date <= lastDate.Date)
                    select m;
            return x;
        }
        /// <summary>
        /// Общая стоимость
        /// </summary>
        /// <param name="sales">Накладная</param>
        /// <returns>Общая стоимость</returns>
        public static decimal TotalPrice(InvoiceForPurchase sales)
        {
            decimal price = 0;
            foreach (var item in sales.Products)
            {
                price = price + item.Price;
            }
            return price;
        }
    }
}
