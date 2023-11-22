using H0AGKU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Logic
{
    public interface ITeamLogic
    {
        void Create(Team item);
        Team Read(int Id);
        void Update(Team item);
        void Delete(int Id);
        IEnumerable<Team> ReadAll();
        double GetAverageSalaryInTeam(int TeamId);
    }
}
