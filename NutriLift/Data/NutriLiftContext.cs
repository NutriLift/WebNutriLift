using Microsoft.EntityFrameworkCore;
using NutriLift.Entities;

namespace NutriLift.Data
{
    public class NutriLiftContext : DbContext
    {
        public NutriLiftContext(DbContextOptions<NutriLiftContext> options)
            : base(options)
        {
        }

        public DbSet<FoodName> FoodName { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodName>(entity =>
            {
                entity.HasKey(e => e.FN_PK);
                entity.ToTable("FoodName");

            });
        }
    }
}
