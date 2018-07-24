using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.DbContex;
using Warehouse_Store.Repositories.EntitiesRepositories;

namespace ConnectionToDateBase
{
    /// <summary>
    /// Repositories for interaction with the database
    /// </summary>
    public static class Unit
    {
        static StoreDbContex contex;
        /// <summary>
        /// Статистика
        /// </summary>
        public static IStatisticsRepositories StatisticsRepository { get; set; }
        public static IContactInformationRepositories ContactInformationRepository { get; set; }
        /// <summary>
        /// Остатки на складе
        /// </summary>
        public static IProductInStockRepositories ProductInStockRepository { get; set; }
        /// <summary>
        /// Категория
        /// </summary>
        public static ICategoryRepositories CategoryRepository { get; private set; }
        /// <summary>
        /// Клиенты
        /// </summary>
        public static IClientUserRepositories ClientUserRepository { get; private set; }
        /// <summary>
        /// Компании поставщики
        /// </summary>
        public static ICompanyProviderRepositories CompanyProviderRepository { get; private set; }
        /// <summary>
        /// Сотрудники
        /// </summary>
        public static IEmployeeRepositories EmployeeRepository { get; private set; }
        /// <summary>
        /// Должность
        /// </summary>
        public static IPositionEmployeeRepositories PositionEmployeeRepository { get; private set; }
        /// <summary>
        /// Накладная закупок
        /// </summary>
        public static IInvoiceForPurchaseRepositories InvoiceForPurchaseRepository { get; private set; }
        /// <summary>
        /// Продукты
        /// </summary>
        public static IProductRepositories ProductRepository { get; private set; }
        /// <summary>
        /// Накладная продаж
        /// </summary>
        public static ISalesInvoiceRepositories SalesInvoiceRepository { get; private set; }
        /// <summary>
        /// Компания покупатель
        /// </summary>
        public static IСompanyСustomerRepositories CompanyСustomerRepository { get; private set; }
        /// <summary>
        ///  Repositories for interaction with the database
        /// </summary>
        static Unit()
        {
            contex = new StoreDbContex("StoreDb");
            StatisticsRepository = new StatisticRepository(contex);
            ContactInformationRepository = new ContactInformationRepository(contex);
            CategoryRepository = new CategoryRepository(contex);
            ClientUserRepository = new ClientUserRepository(contex);
            CompanyProviderRepository = new CompanyProviderRepository(contex);
            EmployeeRepository = new EmployeeRepository(contex);
            PositionEmployeeRepository = new PositionEmployeeRepository(contex);
            InvoiceForPurchaseRepository = new InvoiceForPurchaseRepository(contex);
            ProductRepository = new ProductRepository(contex);
            SalesInvoiceRepository = new SalesInvoiceRepository(contex);
            CompanyСustomerRepository = new CompanyCustomerRepository(contex);
            ProductInStockRepository = new ProductInStockRepository(contex);
        }
    }
}

