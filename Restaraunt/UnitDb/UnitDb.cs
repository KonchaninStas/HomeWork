using EntityBaseData;
using EntityBaseData.Repositories;
using EntityBaseData.Repositories.EntitiesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDb
{
    public static class Unit
    {

        static RestorauntDbContex context;
        public static IDishesRepository DishesRepository { get; private set; }
        public static ILayotsRepository LayotsRepository { get; private set; }
        public static IOrdersRepository OrdersRepository { get; private set; }
        public static IProcucurumentsRepository ProcucurumentsRepository { get; private set; }
        public static IProductsRepository ProductsRepository { get; private set; }
        public static IPurchaserProdutsRepository PurchaserProdutsRepository { get; private set; }
        public static IRecipesRepository RecipesRepository { get; private set; }
        public static IUnitsWeightRepository UnitsWeightRepository { get; private set; }

     static Unit()
            {
            context = new RestorauntDbContex("RestarauntDB");
            DishesRepository = new DishsRepository(context);
            LayotsRepository= new LayotsRepository(context);
           OrdersRepository= new OrdersRepository(context);
            ProcucurumentsRepository = new ProcurementsRepository(context);
            ProductsRepository = new ProductsRepository(context);
            PurchaserProdutsRepository= new PurchaserdProductsRepository(context);
            RecipesRepository = new RecipiesRepository (context);
            UnitsWeightRepository = new UnitsRepository (context);
        }
    }
}
