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

            var teams = new List<Team>()
            {
                new Team(){ID=1,Name="Pittsburgh Penguins",LeagueID=1,HasJuniorSquad=true},
                new Team(){ID=2,Name="New York Rangers",LeagueID=1,HasJuniorSquad=true},
                new Team(){ID=3,Name="Detroit Red Wings",LeagueID=1,HasJuniorSquad=false},
                new Team(){ID=4,Name="Dunaújvárosi Acélbikák",LeagueID=2,HasJuniorSquad=true},
                new Team(){ID=5,Name="Budapest Jégkorong Akadémia HC",LeagueID=2,HasJuniorSquad=true},
                new Team(){ID=6,Name="DVTK Jegesmedvék",LeagueID=2,HasJuniorSquad=false},
                new Team(){ID=7,Name="Ice Tigers Nürnberg",LeagueID=3,HasJuniorSquad=true},
                new Team(){ID=8,Name="Eisbären Berlin",LeagueID=3,HasJuniorSquad=false},
                new Team(){ID=9,Name="EHC Red Bull München",LeagueID=3,HasJuniorSquad=true}
            };
            modelBuilder.Entity<Team>().HasData(teams);

            var players = new List<Player>()
            {
                new Player(){Name="Sidney Crosby",Id=1,Age=36,PlayerSalary=3400000,Position="Midfilder",TeamID=1},
                new Player(){Name="Jonathan Toews",Id=2,Age=35,PlayerSalary=2900000,Position="Midfilder",TeamID=1},
                new Player(){Name="Gilbert Brulé",Id=3,Age=32,PlayerSalary=2750000,Position="GoalTender",TeamID=1},
                new Player(){Name="Nico Sturm",Id=4,Age=28,PlayerSalary=1600000,Position="Midfilder",TeamID=2},
                new Player(){Name="Hári János",Id=5,Age=31,PlayerSalary=1970000,Position="Midfilder",TeamID=2},
                new Player(){Name="Arany Gergely",Id=6,Age=26,PlayerSalary=1500000,Position="GoalTender",TeamID=2},
            };
            modelBuilder.Entity<Player>().HasData(players);
            
        }

    }
}
