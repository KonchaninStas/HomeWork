using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<IdentityUser>
    {
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
