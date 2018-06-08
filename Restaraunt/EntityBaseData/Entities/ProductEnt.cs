using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    [Table("Product")]

    public class ProductEnt : DbEntity
    {
        [StringLength(64)]
        public string Name { get; set; }// название продута
        public decimal Weight { get; set; }//вес
        public UnitWeightEnt UnitWeight { get; set; }//еденица измерения
        public DateTime DeliveryDate { get; set; }//дата получения продукта

        public ProductEnt(string name, decimal weight, UnitWeightEnt unitWeight)
        {
            Name = name;
            Weight = weight;
            UnitWeight = unitWeight;
            DeliveryDate = DateTime.Now;
        }
    }
}
