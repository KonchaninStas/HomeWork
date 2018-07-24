using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
    /// <summary>
    /// Товар в наличие
    /// </summary>
   public class ProductInStockEnt :EntityEnt
    {
        public virtual Dictionary<ProductEnt, int> NumberOfItems { get; set; }
        public DateTime DateInventory { get; set; } = DateTime.Now;
        public ProductInStockEnt()
        {
            NumberOfItems = new Dictionary<ProductEnt, int>();
        }

    }
}
