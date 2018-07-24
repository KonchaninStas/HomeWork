using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Контактная информация
    /// </summary>
    public class ContactInformationEnt : EntityEnt
    {
        /// <summary>
        /// Адрес компании
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Телефон компании
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        public override string ToString()
        {
            string str=null;
            if(Address!=null)
            {
                str+= $"Адрес:{Address}/n";
            } if(Phone!=null)
            {
                str+= $"Телефон:{Phone}/n";
            } if(Email!=null)
            {
                str+= $"Email:{Email}/n";
            }
            return str;
        }
    }
}
