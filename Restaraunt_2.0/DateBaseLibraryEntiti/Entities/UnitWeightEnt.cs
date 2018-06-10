using DateBaseLibraryEntiti.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Entities
{
    [Table("UnitWeight")]
    public class UnitWeightEnt : DbEntity
    {
        public string Unit { get; set; }
        /*  public virtual List<ProductEnt> Products { get; set;*/

        public UnitWeightEnt()
        {
            //Products = new List<ProductEnt>();
        }
        public UnitWeightEnt(string unit)
        {
            Unit = unit;
        }
    }
}
