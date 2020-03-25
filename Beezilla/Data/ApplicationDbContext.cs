using System;
using System.Collections.Generic;
using System.Text;
using Beezilla.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beezilla.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Keeper",
                    NormalizedName = "KEEPER"
                }
            );
        }
        public DbSet<KeeperModel> Keepers { get; set; }
        public DbSet<HiveModel> Hives { get; set; }
        public DbSet<QueenModel> Queens { get; set; }
    }
}
