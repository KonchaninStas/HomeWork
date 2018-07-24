using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Клиент физическое лицо
    /// </summary>
    public class ClientUser : User
    {
        /// <summary>
        /// описание клиента
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// лист накладных покупок клиента
        /// </summary>
        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public virtual ICollection<ContactInformation> ContactInformation { get; set; }
        public ClientUser()
        {
            ContactInformation = new List<ContactInformation>();
            SalesInvoices = new List<SalesInvoice>();
        }
        public override string ToString()
        {
            string str = $"{base.ToString()}Описание:{Description}\n";
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
