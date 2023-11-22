using H0AGKU_HFT_2023241.Models;
using H0AGKU_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> repository;
        public PlayerLogic(IRepository<Player> repository)
        {
            this.repository = repository;
        }
        public void Create(Player item)
        {
            if (item.Id < 0)
            {
                throw new ArgumentException("Player ID must be positive number!");
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

        public IEnumerable<Player> GetPlayersYoungerThanX(int x)
        {
            return repository.ReadAll().Where(t => t.Age < x);
        }

        public int GetYoungestPlayerAge()
        {
            return repository.ReadAll()
                .OrderBy(t => t.Age).First().Age;
        }

        public int GetYoungsterSalaryInfo()
        {
            return repository.ReadAll()
               .Where(t => t.Age > 20)
               .Sum(t => t.PlayerSalary);
        }

        public Player Read(int Id)
        {
            var x = this.repository.Read(Id);
            if (x.Equals(null))
            {
                throw new ArgumentException("Player with this Id is not exists");
            }
            return x;
        }

        public IEnumerable<Player> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Player item)
        {
            this.repository.Update(item);
        }
    }
}
