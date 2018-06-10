using DateBaseLibraryEntiti.Entities;
using LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMethods
{
    static public class LayoutsMethods
    {
        static public bool AddItem(Layouts item)
        {
            return ConnectionToDateBase.Unit.LayotsRepository.AddItem(ConnectionToDateBase.Convert.NewLayoutEnt(item));
        }
        static public bool AddItems(IEnumerable<Layouts> items)
        {
            List<LayoutEnt> layoutEnts = new List<LayoutEnt>();
            foreach (var x in items)
            {
                layoutEnts.Add(ConnectionToDateBase.Convert.NewLayoutEnt(x));
            }
            return ConnectionToDateBase.Unit.LayotsRepository.AddItems(layoutEnts);
        }
        static public bool ChangeItem(Layouts item)
        {
            return ConnectionToDateBase.Unit.LayotsRepository.ChangeItem(ConnectionToDateBase.Convert.NewLayoutEnt(item));
        }
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.LayotsRepository.DeleteItem(id);
        }
        static public Layouts GetItem(int id)
        {
            Layouts layouts = ConnectionToDateBase.Convert.NewLayouts(ConnectionToDateBase.Unit.LayotsRepository.GetItem(id));
            return layouts;
        }
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
