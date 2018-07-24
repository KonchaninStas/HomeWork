using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities;

namespace Warehouse_Store.DbContex
{
    public class MyContextInitializer : DropCreateDatabaseIfModelChanges<StoreDbContex>
    {
        protected override void Seed(StoreDbContex db)
        {
            CategoryEnt[] categories = new CategoryEnt[]
            {
                new CategoryEnt{Name="Продукты", Description="Различные продукты"},
                new CategoryEnt{Name="Авто", Description="Различные авто"},
                new CategoryEnt{Name="Инструменты", Description="Инструменты"},
                new CategoryEnt{Name="Электроника", Description="Телефоны, планшеты и другая электроника"},
            };
            db.Categories.AddRange(categories);
            db.SaveChanges();
            PositionEmployeeEnt position = new PositionEmployeeEnt { Name = "Менеджер", Description = "Оформляет заказы" };
            db.PositionEmployees.Add(position);
            db.SaveChanges();
            EmployeeEnt[] employee = new EmployeeEnt[]
            {
                new EmployeeEnt{Name="Вася", LastName="Васильевич", PositionId=1, Surname="Картошкин" , DateOfBirth=DateTime.Now, DateOfHiring=DateTime.Now,
                    ContactInformation = new ContactInformationEnt[] { new ContactInformationEnt{Phone="+38068044452"}
                }},
                new EmployeeEnt{Name="Степа", LastName="Васильевич", PositionId=1, Surname="Пушкин" ,DateOfBirth=DateTime.Now, DateOfHiring=DateTime.Now,
                    ContactInformation = new ContactInformationEnt[] { new ContactInformationEnt{Phone="+380254852"}
                }}
            };
            db.Employees.AddRange(employee);
            db.SaveChanges();
            ClientUserEnt client = new ClientUserEnt
            { ContactInformation = new ContactInformationEnt[] {  new ContactInformationEnt { Phone = "+380254885" } },
            Description="Важный", Name="Игорь", DateOfBirth=DateTime.Now, LastName="ПЕтрович", Surname="Годин"};
            db.ClientUsers.Add(client);
            db.SaveChanges();
            db.CompanyProviders.Add(new CompanyProviderEnt { Name="Заказ"});
            db.SaveChanges();
            db.InvoiceForPurchases.Add(new InvoiceForPurchaseEnt
            {
                CompanyProviderId=1, EmployeeId=2, Date=DateTime.Now,
            });
            db.SalesInvoices.Add(new SalesInvoiceEnt {Date=DateTime.Now,
                Description="ЛУчшая сделка", EmployeeId=1, ClientUserId=1
            });
            db.Statistics.Add(new StatisticsEnt {Date=DateTime.Now, AverageCostOfGoods = 50, AverageSellingPrice = 25, NumberOfGoodsSold = 2, QuantityOfGoodsInStock = 5 });
            db.Products.AddRange(new ProductEnt[]
            {
                new ProductEnt{DateOfPurchase=DateTime.Now, DateOfSale=DateTime.Now, CategoryId=1, CostPrice=25, Description="Красная", InvoiceForPurchaseId=1, Name="Тачка"/*, SalesInvoiceId=1*/},
                new ProductEnt{DateOfPurchase=DateTime.Now, DateOfSale=DateTime.Now, CategoryId=2, CostPrice=25, Description="Желтый", InvoiceForPurchaseId=1, Name="Чай"/*, SalesInvoiceId=1*/},
                new ProductEnt{DateOfPurchase=DateTime.Now, DateOfSale=DateTime.Now, CategoryId=3, CostPrice=25, Description="Зеленый", InvoiceForPurchaseId=1, Name="Молоток"/*, SalesInvoiceId=1*/},
            });
            db.SaveChanges();
        }
    }
}
