using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class UnitWeight : Entities
    {
        public string Units { get; set; }
        public UnitWeight()
        {
        }
        public UnitWeight(string units)
        {
            Units = units;
        }
    }
}
