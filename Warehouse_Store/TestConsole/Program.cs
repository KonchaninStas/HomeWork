using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionToDateBase;
using Convert;
using Entities;
using EntityMethods;
using Warehouse_Store.DbContex;
using Warehouse_Store.Entities;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CategoryEnt> categories = Unit.CategoryRepository.AllItems.ToList();
            foreach (var item in categories)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
            List<ProductEnt> u = Unit.ProductRepository.AllItems.ToList();
            var x = ProductMethods.Outpoot();
            foreach (var item in x)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(item.CategoryId);
                Console.WriteLine(item.Category.Name);
                Console.WriteLine($"ID накладной{item.InvoiceForPurchase.Id}\n");
            }
            Console.ReadKey();
        }
    }
}
