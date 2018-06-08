using EntityBaseData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBaseData
{
    public class RestorauntDbContex:DbContext
    {
        public DbSet<DishEnt> Dishes { get; set; }
        public DbSet<LayoutEnt> Layouts { get; set; }
        public DbSet<OrderEnt> Orders { get; set; }
        public DbSet<ProcurementJournalEnt> ProcurementJournals { get; set; }
        public DbSet<ProductEnt> Products { get; set; }
        public DbSet<PurchasedProductEnt> PurchasedProducts { get; set; }
        public DbSet<RecipeDishEnt>Recipes { get; set; }
        public DbSet<UnitWeightEnt> UnitWeights { get; set; }
        public DbSet<LayoutEnt> La { get; set; }
       
        public RestorauntDbContex(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

    }
}
