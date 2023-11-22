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
                throw new ArgumentException("Team ID must be positive number!");
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

        public double GetAverageSalaryInTeam(int TeamId)
        {
            var team = this.repository
           .ReadAll()
           .FirstOrDefault(t => t.ID == TeamId);
            return team.Players
            .Select(p => p.PlayerSalary)
            .Average();
        }

        public Team Read(int Id)
        {
            var x = this.repository.Read(Id);
            if (x.Equals(null))
            {
                throw new ArgumentException("Team with this Id is not exists");
            }
            return x;
        }

        public IEnumerable<Team> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Team item)
        {
            this.repository.Update(item);
        }
    }
}
