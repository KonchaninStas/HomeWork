using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Продукт компании
    /// </summary>
    public class Product : Entity
    {
        /// <summary>
        /// имя продукта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// описание продукта
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// коментарий
        /// </summary>
        public string Commit { get; set; }
        /// <summary>
        /// себестоимость
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// Дата изготовления
        /// </summary>
        public DateTime DateOfPurchase { get; set; } = DateTime.Now;
        /// <summary>
        /// накладная закупки
        /// </summary>
        public virtual InvoiceForPurchase InvoiceForPurchase { get; set; }
        //public virtual SalesInvoice SalesInvoice { get; set; }
        //public int? SalesInvoiceId { get; set; }
        public int? InvoiceForPurchaseId { get; set; }
        /// <summary>
        /// дата продажи
        /// </summary>
        public DateTime DateOfSale { get; set; } = DateTime.Now;
        /// <summary>
        /// Категория товара
        /// </summary>
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        /// <summary>
        /// Статус сделки
        /// </summary>
        public bool Status { get; set; } = true;
        /// <summary>
        /// Архивирован ли товар
        /// </summary>
        public bool Archiving { get; set; } = false;
        public override string ToString()
        {
            string str = $"{base.Id}. Название товара:{Name}\n Описание:{Description}\nЦена:{Price}";
            return str;
        }
    }
}
