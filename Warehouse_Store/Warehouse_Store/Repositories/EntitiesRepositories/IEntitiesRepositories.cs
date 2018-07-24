using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities;
using Warehouse_Store.Entities.Interface;
using Warehouse_Store.Repositories.GenericRepositories;

namespace Warehouse_Store.Repositories.EntitiesRepositories
{
    public interface IStatisticsRepositories : IDbGenericRepositories<StatisticsEnt>
    {
    }
    public interface IContactInformationRepositories : IDbGenericRepositories<ContactInformationEnt>
    {
    }
    public interface IProductInStockRepositories : IDbGenericRepositories<ProductInStockEnt>
    {
    }
    public interface ICategoryRepositories : IDbGenericRepositories<CategoryEnt>
    {
    }
    public interface IClientUserRepositories : IDbGenericRepositories<ClientUserEnt>
    {
    }
    public interface ICompanyProviderRepositories : IDbGenericRepositories<CompanyProviderEnt>
    {
    }
    public interface IEmployeeRepositories : IDbGenericRepositories<EmployeeEnt>
    {
    }
    public interface IInvoiceForPurchaseRepositories : IDbGenericRepositories<InvoiceForPurchaseEnt>
    {
    }
    public interface IPositionEmployeeRepositories : IDbGenericRepositories<PositionEmployeeEnt>
    {
    }
    public interface IProductRepositories : IDbGenericRepositories<ProductEnt>
    {
    }
    public interface ISalesInvoiceRepositories : IDbGenericRepositories<SalesInvoiceEnt>
    {
    }
    public interface IСompanyСustomerRepositories : IDbGenericRepositories<CompanyCustomerEnt>
    {
    }

}
