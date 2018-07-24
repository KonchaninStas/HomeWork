using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : User
    {
        /// <summary>
        /// Дата принятия на работу
        /// </summary>
        public DateTime? DateOfHiring { get; set; } = DateTime.Now;
        /// <summary>
        /// Должность
        /// </summary>
        public virtual PositionEmployee Position { get; set; }
        public int? PositionId { get; set; }
        /// <summary>
        /// Коментарии к сотруднику
        /// </summary>
        public string Commit { get; set; }
        /// <summary>
        /// Контактная информация
        /// </summary>
        public virtual ICollection<ContactInformation> ContactInformation { get; set; }
        public Employee()
        {
            ContactInformation = new List<ContactInformation>();
        }
        public override string ToString()
        {
            string str = $"{base.ToString()}\n";
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
