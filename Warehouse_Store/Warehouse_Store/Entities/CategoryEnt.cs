using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.Entities
{
   public class CategoryEnt:EntityEnt
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryEnt ParentCategory { get; set; }
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }
        public virtual ICollection<ProductEnt> Products { get; set; }
        public CategoryEnt ()
        {
            Products = new List<ProductEnt>();
        }
    }
}
