using DateBaseLibraryEntiti.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Entities
{
    [Table("ProcurementJournal")]
    public class ProcurementJournalEnt : DbEntity
    {
        public virtual List<ProductEnt> Products { get; set; }
        public ProcurementJournalEnt()
        {
            Products = new List<ProductEnt>();
        }
        public ProcurementJournalEnt(List<ProductEnt> purchasedProducts)
        {
            Products = purchasedProducts;
        }
    }
}
