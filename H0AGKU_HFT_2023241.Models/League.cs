using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace H0AGKU_HFT_2023241.Models
{
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public bool HasVar { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }
        public League()
        {
            
        }
        public League(int id, string leagueName, string country, bool hasVar)
        {
            Id = id;
            Name = leagueName;
            Country = country;
            HasVar = hasVar;
        }
       

    }
    public class JuniorLeagueInfo
    {
        public JuniorLeagueInfo() { }

        public int LeagueId { get; set; }
        public int JuniorSquadsInLeague { get; set; }

        public JuniorLeagueInfo(int leagueId, int juniorSquadsInLeague)
        {
            LeagueId = leagueId;
            JuniorSquadsInLeague = juniorSquadsInLeague;
        }


    }
}
