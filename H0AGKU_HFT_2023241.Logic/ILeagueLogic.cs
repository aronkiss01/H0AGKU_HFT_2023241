using H0AGKU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Logic
{
    public interface ILeagueLogic
    {
        void Create(League item);
        League Read(int Id);
        void Update(League item);
        void Delete(int Id);
        IEnumerable<League> ReadAll();
        IEnumerable<JuniorLeagueInfo> GetJuniorLeagueInfos();
    }
}
