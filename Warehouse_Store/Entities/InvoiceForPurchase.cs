using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Накладная закупки
    /// </summary>
    public class InvoiceForPurchase : Entity
    {
        /// <summary>
        /// Описание сделки
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Лист продуктов
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
        /// <summary>
        /// Компания поставщик
        /// </summary>
        public virtual CompanyProvider CompanyProvider { get; set; }
        public int? CompanyProviderId { get; set; }
        /// <summary>
        /// Дата закупки
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }
        public int? EmployeeId { get; set; } 
        /// <summary>
        /// Архивирован ли 
        /// </summary>
        public bool Archiving { get; set; }
        public InvoiceForPurchase()
        {
            Products = new List<Product>();
        }
        public override string ToString()
        {
            decimal PriceTotal = 0;
            string str = $"Номер сделки:{Id}\nОписание:{Description}\nКомпания поставщик:" + CompanyProvider.Id + "." + CompanyProvider.Name + "Список товаров:\n";
            foreach (var item in Products)
            {
                str += $"{item.Id}. {item.Name} Цена закупки:{item.CostPrice}\n";
                PriceTotal += item.Price;
            }
            str += $"Общая цена:{PriceTotal}\n";
            str += $"Сотрудник:{Employee.Id}. {Employee.Surname}{Employee.Name}\n";
            return str;
        }
    }
}
