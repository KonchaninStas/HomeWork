using Control_V_3.Models.Entity;
using Control_V_3.Models.Repository;
using DataBase;
using DataBase.Entity;
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
           List<BookEnt> list = new List<BookEnt>
        {
             new BookEnt {Name="ЖД", Author="Карл Ма", Count=150, Category="Еда", Description="Книга про авто", Price=100 },
             new BookEnt {Name="Авто", Author="Карл Маркс", Count=50, Category="Еда" , Description="Книга про авто", Price=100},
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 },
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 },
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Еда" , Description="Книга про авто", Price=100},
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Рецепты" , Description="Книга про авто", Price=100},
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто" , Price=100},
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Еда", Description="Книга про авто" , Price=100},
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 },
            new BookEnt {Name="Морской", Author="Стив Джобс", Count=280, Category="Транспорт", Description="Книга про авто", Price=100 }
        };
            context.AddRange(list);
            context.SaveChanges();
        }
    }
}

