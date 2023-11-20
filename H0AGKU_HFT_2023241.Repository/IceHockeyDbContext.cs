using H0AGKU_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace H0AGKU_HFT_2023241.Repository
{
    public class IceHockeyDbContext:DbContext 
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player > Players { get; set; }

        public IceHockeyDbContext()
        {
            this.Database.EnsureCreated();      
        }

    }
}
