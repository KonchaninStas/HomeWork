using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class Product : Entities
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public UnitWeight UnitWeight { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ShelflifeDate { get; set; }
        public double UnitPrice { get; set; }

        public Product()
        {
        }

        public Product( string name, double weight, UnitWeight unitWeight, DateTime shelflifeDate, double unitPrice)
        {
            Name = name;
            Weight = weight;
            UnitWeight = unitWeight;
            DeliveryDate = DateTime.Now;
            ShelflifeDate = shelflifeDate;
            UnitPrice = unitPrice;
        }
    }
}
