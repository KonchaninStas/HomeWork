using DateBaseLibraryEntiti.Entities;
using LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMethods
{/// <summary>
/// /// <summary>
/// Methods for performing actions in databases
/// </summary>
/// </summary>
    static public class LayoutsMethods
    {  /// <summary>
       /// adding an item to the database
       /// </summary>
       /// <param name="item">Item</param>
       /// <returns>Boolean result</returns>
        static public bool AddItem(Layouts item)
        {
            return ConnectionToDateBase.Unit.LayotsRepository.AddItem(ConnectionToDateBase.Convert.NewLayoutEnt(item));
        }
        /// <summary>
        /// adding an items to the database
        /// </summary>
        /// <param name="items">Items</param>
        /// <returns>Boolean result</returns>
        static public bool AddItems(IEnumerable<Layouts> items)
        {
            List<LayoutEnt> layoutEnts = new List<LayoutEnt>();
            foreach (var x in items)
            {
                layoutEnts.Add(ConnectionToDateBase.Convert.NewLayoutEnt(x));
            }
            return ConnectionToDateBase.Unit.LayotsRepository.AddItems(layoutEnts);
        }
        /// <summary>
        /// The method of searching for an element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool ChangeItem(Layouts item)
        {
            return ConnectionToDateBase.Unit.LayotsRepository.ChangeItem(ConnectionToDateBase.Convert.NewLayoutEnt(item));
        }
        /// <summary>
        /// The method deleting  element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.LayotsRepository.DeleteItem(id);
        }
        /// <summary>
        /// The method of searching for an element in the database by number
        /// </summary>
        /// <param name="id">ID item</param>
        /// <returns>Item</returns>
        static public Layouts GetItem(int id)
        {
            Layouts layouts = ConnectionToDateBase.Convert.NewLayouts(ConnectionToDateBase.Unit.LayotsRepository.GetItem(id));
            return layouts;
        }
        /// <summary>
        /// Method for retrieving a collection of items from a database
        /// </summary>
        /// <returns>Сollection of items</returns>
        static public List<Layouts> Outpoot()
        {
            List<LayoutEnt> layoutEnts = ConnectionToDateBase.Unit.LayotsRepository.AllItems.ToList();
            List<Layouts> layotsList = new List<Layouts>();
            foreach (var l in layoutEnts)
            {
                Layouts layots = ConnectionToDateBase.Convert.NewLayouts(l);
                layotsList.Add(layots);
            }
            return layotsList;
        }
    }
}
