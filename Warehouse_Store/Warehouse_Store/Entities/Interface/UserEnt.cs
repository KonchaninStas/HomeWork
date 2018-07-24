using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Store.Entities.Interface
{
    /// <summary>
    /// Профиль покупателя
    /// </summary>
    public class UserEnt : EntityEnt
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        public UserEnt()
        {
        }
        public override string ToString()
        {
            return $"ФИО:{Surname} {Name} {LastName}/nДата рождения:{DateOfBirth}/n";
        }
    }
}
