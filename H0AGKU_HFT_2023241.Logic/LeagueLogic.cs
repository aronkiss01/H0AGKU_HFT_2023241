using H0AGKU_HFT_2023241.Models;
using H0AGKU_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace H0AGKU_HFT_2023241.Logic
{
    public class LeagueLogic : ILeagueLogic
    {
        IRepository<League> repository;

        public LeagueLogic(IRepository<League> repository)
        {
            this.repository = repository;
        }
        public void Create(League item)
        {
            if (item.Id < 0)
            {
                throw new ArgumentException("League ID must be positive number!");
            }
            else 
            { 
                this.repository.Create(item);
            }
        }

        public void Delete(int Id)
        {
            this.repository.Delete(Id);
        }

        public IEnumerable<JuniorLeagueInfo> GetJuniorLeagueInfos()
        {
            return this.repository.ReadAll()
                .SelectMany(x => x.Teams)
                .GroupBy(x => x.LeagueID)
                .Select(g => new JuniorLeagueInfo() {LeagueId=g.Key,JuniorSquadsInLeague=g.Count(x=> x.HasJuniorSquad)});
        }

        public League Read(int Id)
        {
            var x=this.repository.Read(Id);
            if (x.Equals(null))
            {
                throw new ArgumentException("Player with this Id is not exists");
            }
            return x;
        }

        public IEnumerable<League> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(League item)
        {
           this.repository.Update(item);
        }
    }
}
