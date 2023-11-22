using H0AGKU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Logic
{
    public interface IPlayerLogic
    {
        void Create(Player item);
        Player Read(int Id);
        void Update(Player item);
        void Delete(int Id);
        IEnumerable<Player> ReadAll();
        IEnumerable<Player> GetPlayersYoungerThanX(int x);
        int GetYoungestPlayerAge();
        int GetYoungsterSalaryInfo();
    }
}
