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
    static public class UnitWeightMethods
    {
        /// <summary>
        /// adding an item to the database
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool AddItem(UnitWeight item)
        {
            return ConnectionToDateBase.Unit.UnitsWeightRepository.AddItem(ConnectionToDateBase.Convert.NewUnitWeightEnt(item));
        }
        /// <summary>
        /// adding an items to the database
        /// </summary>
        /// <param name="items">Items</param>
        /// <returns>Boolean result</returns>
        static public bool AddItems(IEnumerable<UnitWeight> items)
        {
            List<UnitWeightEnt> unitWeightEnts = new List<UnitWeightEnt>();
            foreach (var x in items)
            {
                unitWeightEnts.Add(ConnectionToDateBase.Convert.NewUnitWeightEnt(x));
            }
            return ConnectionToDateBase.Unit.UnitsWeightRepository.AddItems(unitWeightEnts);
        }
        /// <summary>
        /// The method of searching for an element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool ChangeItem(UnitWeight item)
        {
            return ConnectionToDateBase.Unit.UnitsWeightRepository.ChangeItem(ConnectionToDateBase.Convert.NewUnitWeightEnt(item));
        }
        /// <summary>
        /// The method deleting  element in the database 
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Boolean result</returns>
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.UnitsWeightRepository.DeleteItem(id);
        }
        /// <summary>
        /// The method of searching for an element in the database by number
        /// </summary>
        /// <param name="id">ID item</param>
        /// <returns>Item</returns>
        static public UnitWeight GetItem(int id)
        {
            UnitWeight unit = ConnectionToDateBase.Convert.NewUnitWeight(ConnectionToDateBase.Unit.UnitsWeightRepository.GetItem(id));
            return unit;
        }
        /// <summary>
        /// Method for retrieving a collection of items from a database
        /// </summary>
        /// <returns>Сollection of items</returns>
        static public List<UnitWeight> Outpoot()
        {
            List<UnitWeightEnt> unitWeightEnts = ConnectionToDateBase.Unit.UnitsWeightRepository.AllItems.ToList();
            List<UnitWeight> units = new List<UnitWeight>();
            foreach (var p in unitWeightEnts)
            {
                UnitWeight unit = ConnectionToDateBase.Convert.NewUnitWeight(p);
                units.Add(unit);
            }
            return units;
        }
    }
}
