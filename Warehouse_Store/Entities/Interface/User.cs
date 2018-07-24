using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    /// <summary>
    /// Профиль человека
    /// </summary>
    public class User : Entity
    {/// <summary>
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
        public User()
        { }
    }
}
