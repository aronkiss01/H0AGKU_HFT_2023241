using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LeagueID { get; set; }

        public bool HasJuniorSquad { get; set; }

        public Team()
        {
            
        }
        public Team(int id, string name, int leagueid, bool hasjuniorsquad)
        {
            ID = id;
            Name = name;
            LeagueID = leagueid;
            HasJuniorSquad = hasjuniorsquad;
            
        }
    }
}
