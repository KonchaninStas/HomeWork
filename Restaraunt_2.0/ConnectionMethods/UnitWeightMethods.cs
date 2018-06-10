using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;

namespace EntityMethods
{
    static public class UnitWeightMethods
    {
        static public bool AddItem(UnitWeight item)
        {
            return ConnectionToDateBase.Unit.UnitsWeightRepository.AddItem(ConnectionToDateBase.Convert.NewUnitWeightEnt(item));
        }
        static public bool AddItems(IEnumerable<UnitWeight> items)
        {
            List<UnitWeightEnt> unitWeightEnts = new List<UnitWeightEnt>();
            foreach (var x in items)
            {
                unitWeightEnts.Add(ConnectionToDateBase.Convert.NewUnitWeightEnt(x));
            }
            return ConnectionToDateBase.Unit.UnitsWeightRepository.AddItems(unitWeightEnts);
        }
        static public bool ChangeItem(UnitWeight item)
        {
            return ConnectionToDateBase.Unit.UnitsWeightRepository.ChangeItem(ConnectionToDateBase.Convert.NewUnitWeightEnt(item));
        }
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.UnitsWeightRepository.DeleteItem(id);
        }
        static public UnitWeight GetItem(int id)
        {
            UnitWeight unit = ConnectionToDateBase.Convert.NewUnitWeight(ConnectionToDateBase.Unit.UnitsWeightRepository.GetItem(id));
            return unit;
        }
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
