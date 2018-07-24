using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{  
    /// <summary>
   /// компания поставщик
   /// </summary>
    public class CompanyProvider:Entity
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
        public virtual ICollection<InvoiceForPurchase> InvoiceForPurchases { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public virtual ICollection<ContactInformation> ContactInformation { get; set; }
        public CompanyProvider()
        {
            ContactInformation = new List<ContactInformation>();
            InvoiceForPurchases = new List<InvoiceForPurchase>();
        }
        public override string ToString()
        {
            string str = $"Название компании:{Name}\nОписание:{Description}\n";
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
