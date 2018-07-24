using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Должность 
    /// </summary>
   public class PositionEmployeeEnt :EntityEnt
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
        public virtual ICollection<EmployeeEnt> Employees { get; set; }
        public PositionEmployeeEnt()
        {
            Employees = new List<EmployeeEnt>();
        }
        public override string ToString()
        {
            return $"Должность:{Name}/nОписание:{Description}/n";
        }
    }
}
