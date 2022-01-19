using EntityFrameworkLabb3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLabb3
{
    public class EntityFrameworkLabb3 : DbContext
    {
        public DbSet<Lagersaldo> GetLagersaldo { get; set; }
        public DbSet<Butiker> GetButiker { get; set; }
        public DbSet<Böcker> GetBöcker { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
