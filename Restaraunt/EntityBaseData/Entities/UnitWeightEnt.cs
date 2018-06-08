using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    [Table("UnitWeight")]
    public class UnitWeightEnt : DbEntity
    {
        
        public string Unit { get; set; }
        public UnitWeightEnt()
        {

        }
        public UnitWeightEnt(string unit)
        {
            Unit = unit;
        }
    }
}
