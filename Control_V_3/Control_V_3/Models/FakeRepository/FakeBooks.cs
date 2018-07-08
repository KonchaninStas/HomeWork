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
        
       
        public static void Start()
        {
            ApplicationContext context = new ApplicationContext();
           List<Book> list = new List<Book>
        {
             new Book {Name="ЖД", Author="Карл Ма", Count=150, Category="Еда", Description="Книга про авто", Price=100 },
             new Book {Name="Авто", Author="Карл Маркс", Count=50, Category="Еда" , Description="Книга про авто", Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 },
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 },
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Еда" , Description="Книга про авто", Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Рецепты" , Description="Книга про авто", Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто" , Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Еда", Description="Книга про авто" , Price=100},
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 },
            new Book {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 }
        };
            context.AddRange(list);
            context.SaveChanges();
        }
    }
}

