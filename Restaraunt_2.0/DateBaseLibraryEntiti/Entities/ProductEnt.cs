using DateBaseLibraryEntiti.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Entities
{
    [Table("Product")]
    public class ProductEnt : DbEntity
    {
        [StringLength(64)]
        public string Name { get; set; }
        public double Weight { get; set; }
        public virtual UnitWeightEnt UnitWeight { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ShelflifeDate { get; set; }
        public double UnitPrice { get; set; }
        public ProductEnt()
        {

        }
        public ProductEnt(string name, double weight, UnitWeightEnt unitWeight, DateTime shelflifeDate, double unitPrice)
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
