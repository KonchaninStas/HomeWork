using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    [Table("PurchasedProduct")]
   public class PurchasedProductEnt : DbEntity
    {
        public virtual ProductEnt Product { get; set; }
        public decimal Price { get; set; }
        public PurchasedProductEnt()
        {
            
        }
        public PurchasedProductEnt(ProductEnt product, decimal price)
        {
            Product = product;
            Price = price;
        }
    }
}
