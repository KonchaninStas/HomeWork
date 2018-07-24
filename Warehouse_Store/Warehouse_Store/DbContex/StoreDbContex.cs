using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities;
using Warehouse_Store.Entities.Interface;

namespace Warehouse_Store.DbContex
{/// <summary>
 /// Контекст БД
 /// </summary>
    public class StoreDbContex : DbContext
    {
        public DbSet<StatisticsEnt> Statistics { get; set; }
        public DbSet<ContactInformationEnt> ContactInformations { get; set; }
        public DbSet<CategoryEnt> Categories { get; set; }
        public DbSet<ClientUserEnt> ClientUsers { get; set; }
        public DbSet<CompanyProviderEnt> CompanyProviders { get; set; }
        public DbSet<EmployeeEnt> Employees { get; set; }
        public DbSet<InvoiceForPurchaseEnt> InvoiceForPurchases { get; set; }
        public DbSet<PositionEmployeeEnt> PositionEmployees { get; set; }
        public DbSet<ProductEnt> Products { get; set; }
        public DbSet<SalesInvoiceEnt> SalesInvoices { get; set; }
        public DbSet<CompanyCustomerEnt> СompanyСustomers { get; set; }
        public DbSet<ProductInStockEnt> ProductInStocks { get; set; }
        static StoreDbContex()
        {
            Database.SetInitializer<StoreDbContex>(new MyContextInitializer());
        }
        public StoreDbContex(string nameOrConnectionString) :base(nameOrConnectionString)
        {
        }
    }
}
