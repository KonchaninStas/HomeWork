using EntityBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDb;

namespace Methods
{
    public class UnitWeight
    {
        public int Id { get; set; }
        public string Units { get; set; }
        public UnitWeight(UnitWeightEnt unit)
        {
            Id = unit.Id;
            Units = unit.Unit;
        }
        void AddUnitWeight(string units)
        {
            UnitWeightEnt unites = new UnitWeightEnt(units);
            Unit.UnitsWeightRepository.AddItem(unites);
        }
        void UnitsWeightDelete(int id)
        {
            Unit.UnitsWeightRepository.DeleteItem(id);
        }
        List<UnitWeight> UnitsWeightOutpoot()
        {

            List<UnitWeightEnt> unitWeightEnts = Unit.UnitsWeightRepository.AllItems.ToList();
            List<UnitWeight> unitsWeights = new List<UnitWeight>();
            foreach (var u in unitWeightEnts)
            {
                UnitWeight units = new UnitWeight(u);
                unitsWeights.Add(units);
            }
            return unitsWeights;
        }
    }
}
