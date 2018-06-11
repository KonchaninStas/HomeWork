using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;

namespace EntityMethods
{/// <summary>
/// Methods for performing actions in databases
/// </summary>
    static public class ProcurementJournalsMethods
    {  /// <summary>
       /// adding an item to the database
       /// </summary>
       /// <param name="item">Item</param>
       /// <returns>Boolean result</returns>
        static public bool AddItem(ProcurementJournals item)
        {
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.AddItem(ConnectionToDateBase.Convert.NewProcurementJournalEnt(item));
        }
        /// <summary>
        /// adding an items to the database
        /// </summary>
        /// <param name="items">Items</param>
        /// <returns>Boolean result</returns>
        static public bool AddItems(IEnumerable<ProcurementJournals> items)
        {
            List<ProcurementJournalEnt> procurementJournalsList = new List<ProcurementJournalEnt>();
            foreach (var x in items)
            {
                procurementJournalsList.Add(ConnectionToDateBase.Convert.NewProcurementJournalEnt(x));
            }
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.AddItems(procurementJournalsList);
        }
        /// <summary>
        /// The method of searching for an element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool ChangeItem(ProcurementJournals item)
        {
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.ChangeItem(ConnectionToDateBase.Convert.NewProcurementJournalEnt(item));
        }
        /// <summary>
        /// The method deleting  element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.ProcucurumentsRepository.DeleteItem(id);
        }
        /// <summary>
        /// The method of searching for an element in the database by number
        /// </summary>
        /// <param name="id">ID item</param>
        /// <returns>Item</returns>
        static public ProcurementJournals GetItem(int id)
        {
            ProcurementJournals journals = ConnectionToDateBase.Convert.NewProcurementJournals(ConnectionToDateBase.Unit.ProcucurumentsRepository.GetItem(id));
            return journals;
        }
        /// <summary>
        /// Method for retrieving a collection of items from a database
        /// </summary>
        /// <returns>Сollection of items</returns>
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
