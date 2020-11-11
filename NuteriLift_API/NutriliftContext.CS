using System;
using Microsoft.EntityFrameworkCore;
using NuteriLift_API.Entities;

namespace NuteriLift_API
{
    public class NutriliftContext : DbContext
    {

        public NutriliftContext(DbContextOptions<NutriliftContext> options) : base(options)
        {
        }

    public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.ToTable("UserDetails");
            });

        }

    }
}

