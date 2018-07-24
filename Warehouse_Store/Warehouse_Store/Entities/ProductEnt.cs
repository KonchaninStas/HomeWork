using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Продукт компании
    /// </summary>
    public class ProductEnt : EntityEnt
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
        public virtual InvoiceForPurchaseEnt InvoiceForPurchase { get; set; }
        //public virtual SalesInvoiceEnt SalesInvoice { get; set; }
        //public int? SalesInvoiceId { get; set; }
        public int? InvoiceForPurchaseId { get; set; }
        /// <summary>
        /// дата продажи
        /// </summary>
        public DateTime DateOfSale { get; set; } = DateTime.Now;
        /// <summary>
        /// Статус сделки
        /// </summary>
        public bool Status { get; set; } = true;
        //[ForeignKey("CategoryId")]
        /// <summary>
        /// категория товара
        /// </summary>
        public CategoryEnt Category { get; set; }
        //[ForeignKey("Category")]
        public int? CategoryId { get; set; }
        /// <summary>
        /// Архивирован ли товар
        /// </summary>
        public bool Archiving { get; set; } = false;
        public override string ToString()
        {
            string str = $"{base.Id}. Название товара:{Name}/n Описание:{Description}/nЦена:{Price}";
            return str;
        }
    }
}
