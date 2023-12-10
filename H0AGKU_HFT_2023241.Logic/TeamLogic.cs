using H0AGKU_HFT_2023241.Models;
using H0AGKU_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Logic
{
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> repository;
        public TeamLogic(IRepository<Team> repository)
        {
            this.repository = repository;
        }
        public void Create(Team item)
        {
            if (item.ID < 0)
            {
                throw new ArgumentException("The team ID cannot be negative!");
            }
            else
            {
                this.repository.Create(item);
            }
        }
        public Team Read(int id)
        {
            var p = this.repository.Read(id);
            if (p == null)
            {
                throw new ArgumentException("Team not exists!");
            }
            return p;
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<Team> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Team item)
        {
            this.repository.Update(item);
        }
        public double GetAverageSalaryInTeam(int teamId)
        {
            var team = this.repository
            .ReadAll()
            .FirstOrDefault(t => t.ID == teamId);
            return team.Players
            .Select(p => p.PlayerSalary)
            .Average();
        }
    }
}
