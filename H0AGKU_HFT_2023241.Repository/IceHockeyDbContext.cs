using H0AGKU_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Repository
{
    public class IceHockeyDbContext : DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public IceHockeyDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ihdb").UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne(t => t.League)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.LeagueID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(t => t.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(t => t.TeamID)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            var leagues = new List<League>()
            {
                new League(){Id=1,LeagueName="National Hockey League",Country="USA,Canada",HasVar=true},
                new League(){Id=2,LeagueName="Erste Liga",Country="Hungary",HasVar=false},
                new League(){Id=3,LeagueName="DEL Bundesliga",Country="Germany",HasVar=true}
            };
            modelBuilder.Entity<League>().HasData(leagues);
        }

    }
}
