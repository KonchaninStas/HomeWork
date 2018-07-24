using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Category:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
        public override string ToString()
        {
            string str = $"Название категории:{Name}\nОписание:{Description}\n";
            if(ParentCategory!=null)
            {
                str = str + $"Родительская категория:{ParentCategory}";
            }
            return str;
        }
        
    }
}
