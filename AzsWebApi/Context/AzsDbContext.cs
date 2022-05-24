using AzsWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AzsWebApi.Context
{
    public sealed class AzsDbContext : DbContext
    {
        public AzsDbContext(DbContextOptions<AzsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Data> Datas { get; set; } = null!;
        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;
    }
}
