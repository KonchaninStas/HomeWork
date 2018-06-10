using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntities
{
    public class ProcurementJournals : Entities
    {
        public List<Product> Products { get; set; }
        public ProcurementJournals()
        {
            Products = new List<Product>();
        }
        public ProcurementJournals( List<Product> products)
        {
            Products = products;
        }

    }
}
