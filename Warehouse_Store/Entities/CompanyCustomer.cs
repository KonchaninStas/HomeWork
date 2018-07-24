using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// компания покупатель
    /// </summary>
    public class CompanyCustomer: Entity
    { 
        /// <summary>
        /// Название компании постовщика
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание компании
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Список накладных
        /// </summary>
        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public virtual ICollection<ContactInformation> ContactInformation { get; set; }
        public CompanyCustomer()
        {
            ContactInformation = new List<ContactInformation>();
            SalesInvoices = new List<SalesInvoice>();
        }
        public override string ToString()
        {
            string str = $"Название компании:{Name}/nОписание:{Description}\n";
            if (ContactInformation != null)
            {
                foreach (var item in ContactInformation)
                {
                    str += item.ToString();
                }
            }
            return str;
        }
    }
}
