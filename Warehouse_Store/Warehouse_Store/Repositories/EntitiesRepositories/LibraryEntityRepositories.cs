using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.DbContex;
using Warehouse_Store.Entities;
using Warehouse_Store.Repositories.GenericRepositories;

namespace Warehouse_Store.Repositories.EntitiesRepositories
{
    public class StatisticRepository : GenericRepositories<StatisticsEnt>, IStatisticsRepositories
    {
    public StatisticRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }

    public class ContactInformationRepository : GenericRepositories<ContactInformationEnt>, IContactInformationRepositories
    {
       
        public ContactInformationRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }

    public class ProductInStockRepository : GenericRepositories<ProductInStockEnt>, IProductInStockRepositories
    {
        public override IQueryable<ProductInStockEnt> AllItems => base.context.ProductInStocks.Include("NumberOfItems").AsQueryable();
        public ProductInStockRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class CategoryRepository : GenericRepositories<CategoryEnt>, ICategoryRepositories
    {
        public override IQueryable<CategoryEnt> AllItems => base.context.Categories.Include("Products").Include("ParentCategory").AsQueryable();
        public CategoryRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }

    public class ClientUserRepository : GenericRepositories<ClientUserEnt>, IClientUserRepositories
    {
        public override IQueryable<ClientUserEnt> AllItems => base.context.ClientUsers.Include("SalesInvoices").Include("ContactInformation").AsQueryable();
        public ClientUserRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class CompanyProviderRepository : GenericRepositories<CompanyProviderEnt>, ICompanyProviderRepositories
    {
        public override IQueryable<CompanyProviderEnt> AllItems => base.context.CompanyProviders.Include("InvoiceForPurchases").Include("ContactInformation").AsQueryable();
        public CompanyProviderRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class EmployeeRepository : GenericRepositories<EmployeeEnt>, IEmployeeRepositories
    {
        public override IQueryable<EmployeeEnt> AllItems => base.context.Employees.Include("Position").Include("ContactInformation").AsQueryable();
        public EmployeeRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class InvoiceForPurchaseRepository : GenericRepositories<InvoiceForPurchaseEnt>, IInvoiceForPurchaseRepositories
    {
        public override IQueryable<InvoiceForPurchaseEnt> AllItems => base.context.InvoiceForPurchases.Include("ProductEnts").Include("CompanyProvider").Include("Employee").AsQueryable();
        public InvoiceForPurchaseRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class PositionEmployeeRepository : GenericRepositories<PositionEmployeeEnt>, IPositionEmployeeRepositories
    {
        public override IQueryable<PositionEmployeeEnt> AllItems => base.context.PositionEmployees.Include("Employees").AsQueryable();
        public PositionEmployeeRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class ProductRepository : GenericRepositories<ProductEnt>, IProductRepositories
    {
        public override IQueryable<ProductEnt> AllItems => base.context.Products.
            Include("Category").Include("InvoiceForPurchase")/*.Include("SalesInvoice")*/.AsQueryable();
        public ProductRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class SalesInvoiceRepository : GenericRepositories<SalesInvoiceEnt>, ISalesInvoiceRepositories
    {
        public override IQueryable<SalesInvoiceEnt> AllItems => base.context.SalesInvoices
            .Include("ProductEnts").Include("CompanyСustomer").Include("ClientUser").Include("Employee").AsQueryable();
        public SalesInvoiceRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }
    public class CompanyCustomerRepository : GenericRepositories<CompanyCustomerEnt>, IСompanyСustomerRepositories
    {
        public override IQueryable<CompanyCustomerEnt> AllItems => base.context.СompanyСustomers.Include("SalesInvoices").Include("ContactInformation").AsQueryable();
        public CompanyCustomerRepository(StoreDbContex Contex) : base(Contex)
        {
        }
    }


}
