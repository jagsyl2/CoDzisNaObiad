using CoDzisNaObiad.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoDzisNaObiad.Infrastructure.Database
{
    public class CoDzisNaObiadDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public CoDzisNaObiadDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Recipe>()
                .Property(x => x.Servings)
                .HasPrecision(10, 2);
        }
    }
}
