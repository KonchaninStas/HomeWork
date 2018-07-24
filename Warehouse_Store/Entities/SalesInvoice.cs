using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Накладная продаж
    /// </summary>
   public class SalesInvoice : Entity
    {
        /// <summary>
        /// Описание сделки
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Лист продуктов
        /// </summary>
        public virtual ICollection<Product> Product { get; set; }
        /// <summary>
        /// Компания покупатель
        /// </summary>
        public virtual CompanyCustomer CompanyСustomer { get; set; }
        public int? CompanyCustomerId { get; set; }
        /// <summary>
        /// Физическое лицо покупатель
        /// </summary>
        public virtual ClientUser ClientUser { get; set; }
        public int? ClientUserId { get; set; }
        /// <summary>
        /// Дата продажи
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
        /// <summary>
        /// Статус сделки
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Архивирован ли 
        /// </summary>
        public bool Archiving { get; set; }
        public SalesInvoice()
        {
            Product = new List<Product>();
        }
        public override string ToString()
        {
            string str = $"Номер сделки:{Id}\nОписание:{Description}\n";
            if (CompanyСustomer != null)
            {
                str += $"Компания покупатель:" + CompanyСustomer.Id + "." + CompanyСustomer.Name + "\n";
            }
            if (ClientUser != null)
            {
                str += $"Клиент:" + ClientUser.Id + "." + ClientUser.Surname + "\n";
            }
            str += $"Список товаров:\n";
            decimal PriceTotal = 0;
            foreach (var item in Product)
            {
                str += $"{item.Id}. {item.Name} Цена :{item.CostPrice}\n";
                PriceTotal += item.Price;
            }
            str += $"Общая цена:{PriceTotal}";
            str += $"Сотрудник:{Employee.Id}. {Employee.Surname}{Employee.Name}";
            return str;
        }
    }
}
