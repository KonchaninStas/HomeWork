using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;

namespace EntityMethods
{
    static public class ProcurementJournalsMethods
    {
        static public bool AddItem(ProcurementJournals item)
        {
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.AddItem(ConnectionToDateBase.Convert.NewProcurementJournalEnt(item));
        }
        static public bool AddItems(IEnumerable<ProcurementJournals> items)
        {
            List<ProcurementJournalEnt> procurementJournalsList = new List<ProcurementJournalEnt>();
            foreach (var x in items)
            {
                procurementJournalsList.Add(ConnectionToDateBase.Convert.NewProcurementJournalEnt(x));
            }
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.AddItems(procurementJournalsList);
        }
        static public bool ChangeItem(ProcurementJournals item)
        {
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.ChangeItem(ConnectionToDateBase.Convert.NewProcurementJournalEnt(item));
        }
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.DeleteItem(id);
        }
        static public ProcurementJournals GetItem(int id)
        {
            ProcurementJournals journals = ConnectionToDateBase.Convert.NewProcurementJournals(ConnectionToDateBase.Unit.ProcucurumentsRepository.GetItem(id));
            return journals;
        }
        static public List<ProcurementJournals> Outpoot()
        {
            List<ProcurementJournalEnt> procurementJournalEnts = ConnectionToDateBase.Unit.ProcucurumentsRepository.AllItems.ToList();
            List<ProcurementJournals> procurements = new List<ProcurementJournals>();
            foreach (var o in procurementJournalEnts)
            {
                ProcurementJournals journals = ConnectionToDateBase.Convert.NewProcurementJournals(o);
                procurements.Add(journals);
            }
            return procurements;
        }
    }
}
