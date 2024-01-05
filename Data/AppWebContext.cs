using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppWeb.Models;

namespace AppWeb.Data
{
    public class AppWebContext : DbContext
    {
        public AppWebContext (DbContextOptions<AppWebContext> options)
            : base(options)
        {
        }

        public DbSet<AppWeb.Models.Menu> Menu { get; set; } = default!;

        public DbSet<AppWeb.Models.Chef>? Chef { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
        .HasMany(l => l.Reservations)
        .WithOne(r => r.Location)
        .HasForeignKey(r => r.LocationID);

        }

        public DbSet<AppWeb.Models.Cuisine>? Cuisine { get; set; }

        public DbSet<AppWeb.Models.Location>? Location { get; set; }

        public DbSet<AppWeb.Models.Client>? Client { get; set; }

        public DbSet<AppWeb.Models.Reservation>? Reservation { get; set; }
    }
}
