using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Накладная закупки
    /// </summary>
    public class InvoiceForPurchaseEnt : EntityEnt
    {
        /// <summary>
        /// Описание сделки
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Лист продуктов
        /// </summary>
        public virtual ICollection<ProductEnt> ProductEnts { get; set; }
        /// <summary>
        /// Компания поставщик
        /// </summary>
        public virtual CompanyProviderEnt CompanyProvider { get; set; }
        public int? CompanyProviderId { get; set; }
        /// <summary>
        /// Дата закупки
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual EmployeeEnt Employee { get; set; }
        public int? EmployeeId { get; set; }
        /// <summary>
        /// Архивирован ли 
        /// </summary>
        public bool Archiving { get; set; }
        public InvoiceForPurchaseEnt ()
        {
            ProductEnts = new List<ProductEnt>();
        }
        public override string ToString()
        {
            decimal PriceTotal = 0;
            string str = $"Номер сделки:{Id}/nОписание:{Description}/nКомпания поставщик:"+CompanyProvider.Id+"."+CompanyProvider.Name+"Список товаров:/n";
            foreach (var item in ProductEnts)
            {
                str += $"{item.Id}. {item.Name} Цена закупки:{item.CostPrice}/n";
                PriceTotal += item.Price;
            }
            str += $"Общая цена:{PriceTotal}";
            str += $"Сотрудник:{Employee.Id}. {Employee.Surname}{Employee.Name}";
            return str;
        }
    }
}
