using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
  /// Контактная информация
  /// </summary>
   public class ContactInformation:Entity
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
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Накладные закупок
        /// </summary>
        public override string ToString()
        {
            string str = null;
            if(Address!=null)
            {
                str+= $"Адрес:{Address}\n";
            } if(Phone!=null)
            {
                str+= $"Телефон:{Phone}\n";
            } if(Email!=null)
            {
                str+= $"Email:{Email}\n";
            }
            return str;
        }
    }
}
