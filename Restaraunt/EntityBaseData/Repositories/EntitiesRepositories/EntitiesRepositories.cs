using EntityBaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData.Repositories.EntitiesRepositories
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
    public interface IPurchaserProdutsRepository : IDbRepositories<PurchasedProductEnt>
    {
    }
    public interface IRecipesRepository : IDbRepositories<RecipeDishEnt>
    {
    }
    public interface IUnitsWeightRepository : IDbRepositories<UnitWeightEnt>
    {
    } 

}
