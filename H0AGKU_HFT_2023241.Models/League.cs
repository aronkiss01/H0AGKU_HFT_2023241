using System;
using System.ComponentModel.DataAnnotations;

namespace H0AGKU_HFT_2023241.Models
{
    public class League
    {
        public int Id { get; set; }
        public string LeagueName { get; set; }
        public string Country { get; set; }
        public bool HasVar { get; set; }

        public League()
        {
            
        }
        public League(int id, string leagueName, string country, bool hasVar)
        {
            Id = id;
            LeagueName = leagueName;
            Country = country;
            HasVar = hasVar;
        }

    }
    public class JuniorLeagueInfo
    {
        public int LeagueId { get; set; }
        public int JuniorSquadsInLeague { get; set; }

        public JuniorLeagueInfo() { }

        public JuniorLeagueInfo(int leagueId, int juniorSquadsInLeague)
        {
            LeagueId = leagueId;
            JuniorSquadsInLeague = juniorSquadsInLeague;
        }


    }
}
