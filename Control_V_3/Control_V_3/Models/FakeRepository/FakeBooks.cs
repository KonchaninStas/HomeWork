using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.FakeBooks
{
    public static class FakeBooks
    {
        static Category cat = new Category { Name = "Транспорт" };
        static List<Book> list = new List<Book>
        {
             new Book {Name="ЖД", Author="Карл Ма", Count=150, Category=cat, Description="Книга про авто", Price=100 },
             new Book {Name="Авто", Author="Карл Маркс", Count=50, Category=cat , Description="Книга про авто", Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat, Description="Книга про авто", Price=100 },
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat, Description="Книга про авто", Price=100 },
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat , Description="Книга про авто", Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat , Description="Книга про авто", Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat, Description="Книга про авто" , Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat, Description="Книга про авто" , Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat, Description="Книга про авто", Price=100 },
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category=cat, Description="Книга про авто", Price=100 }
        };
        public static void Start()
        {
            ApplicationContext context = new ApplicationContext();
            context.Categories.Add(cat);
            context.AddRange(list);
            context.SaveChanges();
        }
    }
}

