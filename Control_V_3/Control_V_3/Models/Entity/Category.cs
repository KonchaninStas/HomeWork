using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Entity
{
    /// <summary>
    /// Category Entity
    /// </summary>
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        /// <summary>
        /// Standart constructor
        /// </summary>
        public Category()
        {
            Books = new List<Book>();
        }
    }
}
