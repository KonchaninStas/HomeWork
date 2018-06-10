using DateBaseLibraryEntiti.Entities;
using DateBaseLibraryEntiti.Repositiries.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLibraryEntiti.Repositiries.EntitiesRepositories
{
    public interface IDishesRepository : IDbRepositories<DishEnt>
    {
    }
    public interface ILayotsRepository : IDbRepositories<LayoutEnt>
    {
    }
    public interface IOrdersRepository : IDbRepositories<OrderEnt>
    {
    }
    public interface IProcucurumentsRepository : IDbRepositories<ProcurementJournalEnt>
    {
    }
    public interface IProductsRepository : IDbRepositories<ProductEnt>
    {
    }
    public interface IRecipesRepository : IDbRepositories<RecipeDishEnt>
    {
    }
    public interface IUnitsWeightRepository : IDbRepositories<UnitWeightEnt>
    {
    }
}
