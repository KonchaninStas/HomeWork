using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Должность 
    /// </summary>
    public class PositionEmployee:Entity
    { 
        /// <summary>
        /// Название должности
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Список сотрудников
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
        public PositionEmployee()
        {
            Employees = new List<Employee>();
        }
        public override string ToString()
        {
            return $"Должность:{Name}\nОписание:{Description}\n";
        }
    }
}
