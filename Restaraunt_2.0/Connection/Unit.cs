using DateBaseLibraryEntiti.Contex;
using DateBaseLibraryEntiti.Repositiries.EntitiesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionToDateBase
{
    /// <summary>
    /// Repositories for interaction with the database
    /// </summary>
    public static class Unit
    {
        static RestorauntDbContex context;
        public static IDishesRepository DishesRepository { get; private set; }
        public static ILayotsRepository LayotsRepository { get; private set; }
        public static IOrdersRepository OrdersRepository { get; private set; }
        public static IProcucurumentsRepository ProcucurumentsRepository { get; private set; }
        public static IProductsRepository ProductsRepository { get; private set; }
        public static IRecipesRepository RecipesRepository { get; private set; }
        public static IUnitsWeightRepository UnitsWeightRepository { get; private set; }
        /// <summary>
        ///  Repositories for interaction with the database
        /// </summary>
        static Unit()
        {
            context = new RestorauntDbContex("RestarauntDB");
            DishesRepository = new DishsRepository(context);
            LayotsRepository = new LayotsRepository(context);
            OrdersRepository = new OrdersRepository(context);
            ProcucurumentsRepository = new ProcurementsRepository(context);
            ProductsRepository = new ProductsRepository(context);
            RecipesRepository = new RecipiesRepository(context);
            UnitsWeightRepository = new UnitsRepository(context);
        }
    }
}
