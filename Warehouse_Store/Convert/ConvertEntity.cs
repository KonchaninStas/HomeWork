using ConnectionToDateBase;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Store.Entities;

namespace Convert
{
    /// <summary>
    /// Класс для конвертации элементов
    /// </summary>
    public static class ConvertEntity
    {
        #region Convert to datebase element
        /// <summary>
        /// Конвертация в статистику БД
        /// </summary>
        /// <param name="statistics">Статистика</param>
        /// <returns>Статистика БД</returns>
        public static StatisticsEnt Convert(Statistics statistics)
        {
            if (statistics != null)
            {
                var x = Unit.StatisticsRepository.GetItem(statistics.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    StatisticsEnt ent = new StatisticsEnt
                    {
                        AverageCostOfGoods = statistics.AverageCostOfGoods,
                        AverageSellingPrice = statistics.AverageSellingPrice,
                        Date = statistics.Date,
                        Id = statistics.Id,
                        NumberOfGoodsSold = statistics.NumberOfGoodsSold,
                        QuantityOfGoodsInStock = statistics.QuantityOfGoodsInStock
                    };
                    return ent;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в контактную информацию БД
        /// </summary>
        /// <param name="contact">Контактная информация </param>
        /// <returns>Контактная информация БД</returns>
        public static ContactInformationEnt Convert(ContactInformation contact)
        {
            if (contact != null)
            {
                var x = Unit.ContactInformationRepository.GetItem(contact.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    ContactInformationEnt ent = new ContactInformationEnt
                    {
                        Address = contact.Address,
                        Email = contact.Email,
                        Id = contact.Id,
                        Phone = contact.Phone
                    };
                    return ent;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в остатки на складе БД
        /// </summary>
        /// <param name="product">остатки на складе</param>
        /// <returns>остатки на складе БД</returns>
        public static ProductInStockEnt Convert(ProductInStock product)
        {
            if (product != null)
            {
                var x = Unit.ProductInStockRepository.GetItem(product.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    Dictionary<ProductEnt, int> pairs = new Dictionary<ProductEnt, int>();
                    foreach (var item in product.NumberOfItems)
                    {
                        pairs.Add(Convert(item.Key), item.Value);
                    }
                    ProductInStockEnt productInStock = new ProductInStockEnt
                    {
                        DateInventory = product.DateInventory,
                        Id = product.Id,
                        NumberOfItems = pairs
                    };
                    return productInStock;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в категорию БД
        /// </summary>
        /// <param name="category">Категория</param>
        /// <returns>Категория БД</returns>
        public static CategoryEnt Convert(Category category)
        {

            if (category != null)
            {
                List<ProductEnt> products = new List<ProductEnt>();
                foreach (var item in category.Products)
                {
                    products.Add(Convert(item));
                }
                CategoryEnt categoryEnt = new CategoryEnt
                {
                    Description = category.Description,
                    Id = category.Id,
                    ParentCategoryId = category.ParentCategoryId,
                    Products = products,
                    Name = category.Name,
                    ParentCategory = Convert(category.ParentCategory)
                };
                return categoryEnt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в клиента физическое лицо БД
        /// </summary>
        /// <param name="client">Клиент физическое лицо </param>
        /// <returns>Клиент физическое лицо БД</returns>
        public static ClientUserEnt Convert(ClientUser client)
        {
            if (client != null)
            {
                var x = Unit.ClientUserRepository.GetItem(client.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    List<ContactInformationEnt> list = new List<ContactInformationEnt>();
                    foreach (var item in client.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                    List<SalesInvoiceEnt> sales = new List<SalesInvoiceEnt>();
                    foreach (var item in client.SalesInvoices)
                    {
                        sales.Add(Convert(item));
                    }
                    ClientUserEnt clientEnt = new ClientUserEnt
                    {
                        Name = client.Name,
                        DateOfBirth = client.DateOfBirth,
                        Description = client.Description,
                        LastName = client.LastName,
                        SalesInvoices = sales,
                        Surname = client.Surname,
                        Id = client.Id,
                        ContactInformation = list
                    };
                    return clientEnt;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в компанию клиента БД
        /// </summary>
        /// <param name="client">Компания клиент  </param>
        /// <returns>Компания клиент БД</returns>
        public static CompanyCustomerEnt Convert(CompanyCustomer company)
        {
            if (company != null)
            {
                var x = Unit.CompanyСustomerRepository.GetItem(company.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    List<ContactInformationEnt> list = new List<ContactInformationEnt>();
                    foreach (var item in company.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                    List<SalesInvoiceEnt> salesInvoiceEnts = new List<SalesInvoiceEnt>();
                    foreach (var item in company.SalesInvoices)
                    {
                        salesInvoiceEnts.Add(Convert(item));
                    }
                    CompanyCustomerEnt companyEnt = new CompanyCustomerEnt
                    {
                        Description = company.Description,
                        Name = company.Name,
                        Id = company.Id,
                        SalesInvoices = salesInvoiceEnts,
                        ContactInformation = list
                    };
                    return companyEnt;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в компанию поставщика БД
        /// </summary>
        /// <param name="client">Компания поставщик </param>
        /// <returns>Компания поставщик БД </returns>
        public static CompanyProviderEnt Convert(CompanyProvider companyProvider)
        {
            if (companyProvider != null)
            {
                var x = Unit.CompanyProviderRepository.GetItem(companyProvider.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    List<ContactInformationEnt> list = new List<ContactInformationEnt>();
                    foreach (var item in companyProvider.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                    List<InvoiceForPurchaseEnt> invoiceForPurchaseEnts = new List<InvoiceForPurchaseEnt>();
                    foreach (var item in companyProvider.InvoiceForPurchases)
                    {
                        invoiceForPurchaseEnts.Add(Convert(item));
                    }
                    CompanyProviderEnt companyProviderEnt = new CompanyProviderEnt
                    {
                        InvoiceForPurchases = invoiceForPurchaseEnts,
                        Description = companyProvider.Description,
                        Id = companyProvider.Id,
                        Name = companyProvider.Name,
                        ContactInformation = list

                    };
                    return companyProviderEnt;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в сотрудника БД
        /// </summary>
        /// <param name="client">Сотрудник</param>
        /// <returns>Сотрудник БД </returns>
        public static EmployeeEnt Convert(Employee employee)
        {
            if (employee != null)
            {
                var x = Unit.EmployeeRepository.GetItem(employee.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    List<ContactInformationEnt> list = new List<ContactInformationEnt>();
                    foreach (var item in employee.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                    EmployeeEnt employeeEnt = new EmployeeEnt
                    {
                        DateOfBirth = employee.DateOfBirth,
                        Commit = employee.Commit,
                        DateOfHiring = employee.DateOfHiring,
                        Id = employee.Id,
                        PositionId = employee.PositionId,
                        LastName = employee.LastName,
                        Name = employee.Name,
                        Position = Convert(employee.Position),
                        Surname = employee.Surname,
                        ContactInformation = list
                    };
                    return employeeEnt;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в накладную закупок БД
        /// </summary>
        /// <param name="client">Накладная закупок</param>
        /// <returns>Накладная закупок БД</returns>
        public static InvoiceForPurchaseEnt Convert(InvoiceForPurchase invoiceForPurchase)
        {
            if (invoiceForPurchase != null)
            {
                var x = Unit.InvoiceForPurchaseRepository.GetItem(invoiceForPurchase.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    List<ProductEnt> productEnts = new List<ProductEnt>();
                    foreach (var item in invoiceForPurchase.Products)
                    {
                        productEnts.Add(Convert(item));
                    }
                    InvoiceForPurchaseEnt invoiceForPurchaseEnt = new InvoiceForPurchaseEnt
                    {
                        CompanyProvider = Convert(invoiceForPurchase.CompanyProvider),
                        Date = invoiceForPurchase.Date,
                        Description = invoiceForPurchase.Description,
                        Employee = Convert(invoiceForPurchase.Employee),
                        Id = invoiceForPurchase.Id,
                        CompanyProviderId = invoiceForPurchase.CompanyProviderId,
                        EmployeeId = invoiceForPurchase.EmployeeId,
                        ProductEnts = productEnts,
                        Archiving = invoiceForPurchase.Archiving
                    };
                    return invoiceForPurchaseEnt;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в должность БД
        /// </summary>
        /// <param name="client">Должность</param>
        /// <returns>Должность БД</returns>
        public static PositionEmployeeEnt Convert(PositionEmployee position)
        {
            if (position != null)
            {
                var x = Unit.PositionEmployeeRepository.GetItem(position.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    List<EmployeeEnt> ents = new List<EmployeeEnt>();
                    foreach (var item in position.Employees)
                    {
                        ents.Add(Convert(item));
                    }
                    PositionEmployeeEnt positionEmployee = new PositionEmployeeEnt
                    {
                        Description = position.Description,
                        Id = position.Id,
                        Employees = ents,
                        Name = position.Name
                    };
                    return positionEmployee;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в продукт БД
        /// </summary>
        /// <param name="client">Продукт</param>
        /// <returns>Продукт БД</returns>
        public static ProductEnt Convert(Product product)
        {
            if (product != null)
            {
                var x = Unit.ProductRepository.GetItem(product.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    ProductEnt productEnt = new ProductEnt
                    {
                        Description = product.Description,
                        //SalesInvoice = Convert(product.SalesInvoice),
                        //SalesInvoiceId = product.SalesInvoiceId,
                        InvoiceForPurchase = Convert(product.InvoiceForPurchase),
                        Commit = product.Commit,
                        CostPrice = product.CostPrice,
                        DateOfPurchase = product.DateOfPurchase,
                        DateOfSale = product.DateOfSale,
                        Id = product.Id,
                        CategoryId = product.CategoryId,
                        InvoiceForPurchaseId = product.InvoiceForPurchaseId,
                        Name = product.Name,
                        Price = product.Price,
                        Category = Convert(product.Category),
                        Archiving = product.Archiving,
                        Status = product.Status
                    };
                    return productEnt;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в накладную продаж БД
        /// </summary>
        /// <param name="client">Накладная продаж</param>
        /// <returns>Накладная продаж БД</returns>
        public static SalesInvoiceEnt Convert(SalesInvoice sales)
        {
            if (sales != null)
            {
                var x = Unit.SalesInvoiceRepository.GetItem(sales.Id);
                if (x != null)
                {
                    return x;
                }
                else
                {
                    List<ProductEnt> products = new List<ProductEnt>();
                    foreach (var item in sales.Product)
                    {
                        products.Add(Convert(item));
                    }
                    SalesInvoiceEnt ent = new SalesInvoiceEnt
                    {
                        ClientUser = Convert(sales.ClientUser),
                        Date = sales.Date,
                        Description = sales.Description,
                        CompanyСustomer = Convert(sales.CompanyСustomer),
                        Employee = Convert(sales.Employee),
                        Id = sales.Id,
                        ClientUserId = sales.ClientUserId,
                        CompanyCustomerId = sales.CompanyCustomerId,
                        EmployeeId = sales.EmployeeId,
                        ProductEnts = products,
                        Archiving = sales.Archiving,
                        Status = sales.Status
                    };
                    return ent;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region Convert to entity
        /// <summary>
        /// Конвертация в контактную информацию 
        /// </summary>
        /// <param name="contact">Контактная информация БД </param>
        /// <returns>Контактная информация </returns>
        public static ContactInformation Convert(ContactInformationEnt contact)
        {
            if (contact != null)
            {
                ContactInformation ent = new ContactInformation
                {
                    Address = contact.Address,
                    Email = contact.Email,
                    Id = contact.Id,
                    Phone = contact.Phone
                };
                return ent;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в остатки на складе 
        /// </summary>
        /// <param name="product">остатки на складе БД</param>
        /// <returns>остатки на складе</returns>
        public static ProductInStock Convert(ProductInStockEnt product ,bool logic = true)
        {
            if (product != null)
            {
                Dictionary<Product, int> pairs = null;
                if (logic==true)
                {
                    pairs = new Dictionary<Product, int>();
                    foreach (var item in product.NumberOfItems)
                    {
                        pairs.Add(Convert(item.Key,false), item.Value);
                    }
                }
                ProductInStock productInStock = new ProductInStock
                {
                    DateInventory = product.DateInventory,
                    Id = product.Id,
                    NumberOfItems = pairs
                };
                return productInStock;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в клиента физическое лицо 
        /// </summary>
        /// <param name="client">Клиент физическое лицо БД </param>
        /// <returns>Клиент физическое лицо </returns>
        public static ClientUser Convert(ClientUserEnt client, bool logic = true)
        {
            if (client != null)
            {
                List<ContactInformation> list = null;
                List<SalesInvoice> sales = null;
                if (logic==true)
                {
                    list = new List<ContactInformation>();
                    foreach (var item in client.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                    sales = new List<SalesInvoice>();
                    foreach (var item in client.SalesInvoices)
                    {
                        sales.Add(Convert(item, false));
                    }
                }
                ClientUser clientEnt = new ClientUser
                {
                    Name = client.Name,
                    DateOfBirth = client.DateOfBirth,
                    Description = client.Description,
                    LastName = client.LastName,
                    SalesInvoices = sales,
                    Surname = client.Surname,
                    Id = client.Id,
                    ContactInformation = list
                };
                return clientEnt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в компанию клиента 
        /// </summary>
        /// <param name="client">Компания клиент БД </param>
        /// <returns>Компания клиент </returns>
        public static CompanyCustomer Convert(CompanyCustomerEnt company,bool logic = true)
        {
            if (company != null)
            {
                List<ContactInformation> list = null;
                List<SalesInvoice> salesInvoiceEnts = null;
                if (logic==true)
                {
                    list = new List<ContactInformation>();
                    foreach (var item in company.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                    salesInvoiceEnts = new List<SalesInvoice>();
                    foreach (var item in company.SalesInvoices)
                    {
                        salesInvoiceEnts.Add(Convert(item, false));
                    }
                }
                CompanyCustomer companyEnt = new CompanyCustomer
                {
                    Description = company.Description,
                    Name = company.Name,
                    Id = company.Id,
                    SalesInvoices = salesInvoiceEnts,
                    ContactInformation = list
                };
                return companyEnt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в компанию поставщика 
        /// </summary>
        /// <param name="client">Компания поставщик  БД</param>
        /// <returns>Компания поставщик </returns>
        public static CompanyProvider Convert(CompanyProviderEnt companyProvider, bool logic = true)
        {
            if (companyProvider != null)
            {
                List<ContactInformation> list = null;
                List<InvoiceForPurchase> invoiceForPurchaseEnts = null;
                if (logic==true)
                {
                  list = new List<ContactInformation>();
                    foreach (var item in companyProvider.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                    invoiceForPurchaseEnts = new List<InvoiceForPurchase>();
                    foreach (var item in companyProvider.InvoiceForPurchases)
                    {
                        invoiceForPurchaseEnts.Add(Convert(item,false));
                    }
                }
                CompanyProvider companyProviderEnt = new CompanyProvider
                {
                    InvoiceForPurchases = invoiceForPurchaseEnts,
                    Description = companyProvider.Description,
                    Id = companyProvider.Id,
                    Name = companyProvider.Name,
                    ContactInformation = list
                };
                return companyProviderEnt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в сотрудника 
        /// </summary>
        /// <param name="client">Сотрудник БД</param>
        /// <returns>Сотрудник</returns>
        public static Employee Convert(EmployeeEnt employee, bool logic = true)
        {
            if (employee != null)
            {
                List<ContactInformation> list = null;
                PositionEmployee position = null;
                if (logic==true)
                {
                    position = Convert(employee.Position);
                   list = new List<ContactInformation>();
                    foreach (var item in employee.ContactInformation)
                    {
                        list.Add(Convert(item));
                    }
                }
                Employee employeeEnt = new Employee
                {
                    DateOfBirth = employee.DateOfBirth,
                    Commit = employee.Commit,
                    DateOfHiring = employee.DateOfHiring,
                    Id = employee.Id,
                    LastName = employee.LastName,
                    Name = employee.Name,
                    PositionId = employee.PositionId,
                    Position = position,
                    Surname = employee.Surname,
                    ContactInformation = list
                };
                return employeeEnt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в накладную закупок 
        /// </summary>
        /// <param name="client">Накладная закупок БД</param>
        /// <returns>Накладная закупок</returns>
        public static InvoiceForPurchase Convert(InvoiceForPurchaseEnt invoiceForPurchase, bool logic = true)
        {
            if (invoiceForPurchase != null)
            {
                List<Product> productEnts = null;
                Employee employee = null;
                CompanyProvider companyProvider = null;
                if (logic==true)
                {
                    companyProvider = Convert(invoiceForPurchase.CompanyProvider,false);
                    employee = Convert(invoiceForPurchase.Employee,false);
                    productEnts = new List<Product>();
                    foreach (var item in invoiceForPurchase.ProductEnts)
                    {
                        productEnts.Add(Convert(item,false));
                    }
                }
                InvoiceForPurchase invoiceForPurchaseEnt = new InvoiceForPurchase
                {
                    Date = invoiceForPurchase.Date,
                    Description = invoiceForPurchase.Description,
                    CompanyProviderId = invoiceForPurchase.CompanyProviderId,
                    EmployeeId = invoiceForPurchase.EmployeeId,
                    Employee = employee ,
                    Id = invoiceForPurchase.Id,
                    CompanyProvider = companyProvider, 
                    Archiving = invoiceForPurchase.Archiving,
                    Products = productEnts
                };
                return invoiceForPurchaseEnt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в должность 
        /// </summary>
        /// <param name="client">Должность БД</param>
        /// <returns>Должность</returns>
        public static PositionEmployee Convert(PositionEmployeeEnt position, bool logic = true)
        {
            List<Employee> ents = null;
            if (logic==true)
            {
                ents = new List<Employee>();
                foreach (var item in position.Employees)
                {
                    ents.Add(Convert(item,false));
                }
            }
           
            if (position != null)
            {
                PositionEmployee positionEmployee = new PositionEmployee
                {
                    Description = position.Description,
                    Id = position.Id,
                    Employees = ents,
                    Name = position.Name
                };
                return positionEmployee;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Конвертация в статистику 
        /// </summary>
        /// <param name="statistics">Статистика БД</param>
        /// <returns>Статистика </returns>
        public static Statistics Convert(StatisticsEnt statistics)
        {
            if (statistics != null)
            {
                Statistics ent = new Statistics
                {
                    AverageCostOfGoods = statistics.AverageCostOfGoods,
                    AverageSellingPrice = statistics.AverageSellingPrice,
                    Date = statistics.Date,
                    Id = statistics.Id,
                    NumberOfGoodsSold = statistics.NumberOfGoodsSold,
                    QuantityOfGoodsInStock = statistics.QuantityOfGoodsInStock
                };
                return ent;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в накладную продаж 
        /// </summary>
        /// <param name="client">Накладная продаж БД</param>
        /// <returns>Накладная продаж</returns>
        public static SalesInvoice Convert(SalesInvoiceEnt sales, bool logic = true)
        {
            if (sales != null)
            {
                CompanyCustomer companyСustomer = null;
                ClientUser clientUser = null;
                Employee employee = null;
                if (logic == true)
                {
                    companyСustomer = Convert(sales.CompanyСustomer, false);
                    clientUser = Convert(sales.ClientUser, false);
                    employee = Convert(sales.Employee, false);
                }
                List<Product> products = new List<Product>();
                foreach (var item in sales.ProductEnts)
                {
                    products.Add(Convert(item));
                }
                SalesInvoice ent = new SalesInvoice
                {
                    ClientUser = clientUser,
                    Date = sales.Date,
                    ClientUserId = sales.ClientUserId,
                    CompanyCustomerId = sales.CompanyCustomerId,
                    EmployeeId = sales.EmployeeId,
                    Description = sales.Description,
                    CompanyСustomer = companyСustomer,
                    Employee = employee,
                    Id = sales.Id,
                    Archiving = sales.Archiving,
                    Product = products,
                    Status = sales.Status
                };
                return ent;
            }
            return null;
        }
        /// <summary>
        /// Конвертация в продукт
        /// </summary>
        /// <param name="client">Продукт БД</param>
        /// <returns>Продукт</returns>
        public static Product Convert(ProductEnt product, bool logic = true)
        {
            if (product != null)
            {
                SalesInvoice sales = null;
                InvoiceForPurchase invoiceForPurchase = null;
                Category category=null;
                if (logic== true)
                {
                    //sales = Convert(product.SalesInvoice, false);
                    category = Convert(product.Category, false);
                    invoiceForPurchase = Convert(product.InvoiceForPurchase, false);
                }
                Product productEnt = new Product
                {
                    Description = product.Description,
                    //SalesInvoice = sales,
                    //SalesInvoiceId=product.SalesInvoiceId,
                    InvoiceForPurchase = invoiceForPurchase,
                    Commit = product.Commit,
                    InvoiceForPurchaseId = product.InvoiceForPurchaseId,
                    CategoryId = product.CategoryId,
                    CostPrice = product.CostPrice,
                    DateOfPurchase = product.DateOfPurchase,
                    DateOfSale = product.DateOfSale,
                    Id = product.Id,
                    Name = product.Name,
                    Archiving = product.Archiving,
                    Category =category , /*new { Name = product.Category.Name },*/
                    Price = product.Price,
                    Status = product.Status
                };
                return productEnt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Конвертация в категорию 
        /// </summary>
        /// <param name="category">Категория БД</param>
        /// <returns>Категория </returns>
        public static Category Convert(CategoryEnt category, bool logic = true)
        {
            if (category != null)
            {
                List<Product> products=null;
                if (logic == true)
                {
                    products = new List<Product>();
                    foreach (var item in category.Products)
                    {
                        products.Add(Convert(item, false));
                    }
                }
                Category categorys = new Category
                {
                    Description = category.Description,
                    Id = category.Id,
                    ParentCategoryId = category.ParentCategoryId,
                    Name = category.Name,
                    ParentCategory = Convert(category.ParentCategory,false),
                    Products = products
                };
                return categorys;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
