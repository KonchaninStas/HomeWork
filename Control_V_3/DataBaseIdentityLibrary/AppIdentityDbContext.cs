using DataBaseIdentityLibrary.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBaseIdentityLibrary
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        DbSet<LoginModelEnt> Logins { get; set; }
        public AppIdentityDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LENOVO-PC;Database=BooksShopIdentity;Trusted_Connection=True;");
        }
    }
}
