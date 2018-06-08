using EntityBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDb;

namespace Methods
{
    public class ProcurementJournals
    {
        public int Id { get; set; }
        public List<PurchasedProducts> Products { get; set; }
        public ProcurementJournals(ProcurementJournalEnt procurement)
        {
            Id = procurement.Id;
            foreach (var x in procurement.Products)
            {
                Products.Add(new PurchasedProducts(x));
            }
        }
        void AddProcurementJournal(List<PurchasedProductEnt> products)
        {
            ProcurementJournalEnt journal = new ProcurementJournalEnt(products);
            Unit.ProcucurumentsRepository.AddItem(journal);
        }
        void ProcurementJournalsDelete(int id)
        {
            Unit.ProcucurumentsRepository.DeleteItem(id);
        }
        List<ProcurementJournals> ProcurementJournalsOutpoot()
        {

            List<ProcurementJournalEnt> procurementJournalEnts = Unit.ProcucurumentsRepository.AllItems.ToList();
            List<ProcurementJournals> procurementJournals = new List<ProcurementJournals>();
            foreach (var p in procurementJournalEnts)
            {
                ProcurementJournals journals = new ProcurementJournals(p);
                procurementJournals.Add(journals);
            }
            return procurementJournals;
        }
    }
}
