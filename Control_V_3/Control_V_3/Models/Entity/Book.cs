using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Entity
{
    /// <summary>
    /// Book Entity
    /// </summary>
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Standart constructor
        /// </summary>
        public Book()
        {

        }
    }
}
