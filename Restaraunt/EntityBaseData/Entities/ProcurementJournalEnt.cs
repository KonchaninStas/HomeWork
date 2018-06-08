using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    [Table("ProcurementJournal")]
    public  class ProcurementJournalEnt : DbEntity
    {
       
        public virtual List<PurchasedProductEnt> Products { get; set; }
        public ProcurementJournalEnt()
        {
            Products = new List<PurchasedProductEnt>();
        }
        public ProcurementJournalEnt(List<PurchasedProductEnt> purchasedProducts)
        {
            Products = purchasedProducts;
        }
    }
}
