using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// компания поставщик
    /// </summary>
   public class CompanyProviderEnt:EntityEnt
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
        public virtual ICollection<InvoiceForPurchaseEnt> InvoiceForPurchases { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public virtual ICollection<ContactInformationEnt> ContactInformation { get; set; }
        public CompanyProviderEnt()
        {
            ContactInformation = new List<ContactInformationEnt>();
            InvoiceForPurchases = new List<InvoiceForPurchaseEnt>();
        }
        public override string ToString()
        {
            string str = $"Название компании:{Name}/nОписание:{Description}/n";
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
