using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Сотрудник
    /// </summary>
  public  class EmployeeEnt:UserEnt
    {
        /// <summary>
        /// Дата принятия на работу
        /// </summary>
        public DateTime? DateOfHiring { get; set; } = DateTime.Now;
        /// <summary>
        /// Должность
        /// </summary>
        public virtual PositionEmployeeEnt  Position { get; set; }
        public int? PositionId { get; set; }
        /// <summary>
        /// Коментарии к сотруднику
        /// </summary>
        public string Commit { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public virtual ICollection<ContactInformationEnt> ContactInformation { get; set; }
        public EmployeeEnt ()
        {
            ContactInformation = new List<ContactInformationEnt>();
        }
        public override string ToString()
        {
            string str = $"{base.ToString()}/n";
            str += $"{Position.ToString()}";
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
