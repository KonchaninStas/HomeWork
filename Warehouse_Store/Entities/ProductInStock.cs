using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Товар в наличие
    /// </summary>
    public class ProductInStock : Entity
    {
        public virtual Dictionary<Product, int> NumberOfItems { get; set; }
        public DateTime DateInventory { get; set; } = DateTime.Now;
        public ProductInStock()
        {
            NumberOfItems = new Dictionary<Product, int>();
        }
    }
}
