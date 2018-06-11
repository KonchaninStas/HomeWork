using DateBaseLibraryEntiti.Contex;
using DateBaseLibraryEntiti.Entities;
using DateBaseLibraryEntiti.Repositiries.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Repositiries.EntitiesRepositories
{/// <summary>
/// Repositorises 
/// </summary>
    public class DishsRepository : GenericRepositories<DishEnt>, IDishesRepository
    {
        public DishsRepository(RestorauntDbContex Contex)
            : base(Contex)
        {
        }
    }
    public class LayotsRepository : GenericRepositories<LayoutEnt>, ILayotsRepository
    {
        public LayotsRepository(RestorauntDbContex Contex) : base(Contex)
        {
        }
    }
    public class OrdersRepository : GenericRepositories<OrderEnt>, IOrdersRepository
    {
        public OrdersRepository(RestorauntDbContex Contex) : base(Contex)
        {
        }
    }
    public class ProcurementsRepository : GenericRepositories<ProcurementJournalEnt>, IProcucurumentsRepository
    {
        public ProcurementsRepository(RestorauntDbContex Contex) : base(Contex)
        {
        }
    }
    public class ProductsRepository : GenericRepositories<ProductEnt>, IProductsRepository
    {
        public ProductsRepository(RestorauntDbContex Contex) : base(Contex)
        {
        }
    }
    public class RecipiesRepository : GenericRepositories<RecipeDishEnt>, IRecipesRepository
    {
        public RecipiesRepository(RestorauntDbContex Contex) : base(Contex)
        {
        }
    }
    public class UnitsRepository : GenericRepositories<UnitWeightEnt>, IUnitsWeightRepository
    {
        public UnitsRepository(RestorauntDbContex Contex) : base(Contex)
        {
        }
    }
}
