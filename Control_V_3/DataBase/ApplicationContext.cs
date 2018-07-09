using DataBase.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BookEnt> Books { get; set; }
        public DbSet<OrderEnt> Orders { get; set; }
        public DbSet<CartLineEnt> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LENOVO-PC;Database=BooksShop;Trusted_Connection=True;");
        }
    }
}
