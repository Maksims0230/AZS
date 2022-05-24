using AspApp.WFEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AzsApp.WFEF.Context
{
    internal class AzsDbContext : DbContext
    {
        public DbSet<Data> Datas { get; set; } = null!;
        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-D5LQVBB\MAKSIMSSQL;Initial Catalog=AZS_Db;Persist Security Info=True;User ID=sa;Password=11223344");
        }
    }
}
