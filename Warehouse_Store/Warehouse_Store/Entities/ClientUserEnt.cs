using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Клиент физическое лицо
    /// </summary>
   public class ClientUserEnt:UserEnt
    {
        /// <summary>
        /// описание клиента
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// лист накладных покупок клиента
        /// </summary>
        public virtual ICollection<SalesInvoiceEnt> SalesInvoices { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public virtual ICollection<ContactInformationEnt> ContactInformation { get; set; }
        public ClientUserEnt ()
        {
            ContactInformation = new List<ContactInformationEnt>();
            SalesInvoices = new List<SalesInvoiceEnt>();
        }
        public override string ToString()
        {
            string str= $"{base.ToString()}Описание:{Description}/n";
            if(ContactInformation!=null)
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
