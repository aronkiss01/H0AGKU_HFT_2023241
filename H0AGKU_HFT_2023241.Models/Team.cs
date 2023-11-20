using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(League))]
        public int LeagueID { get; set; }
        public bool HasJuniorSquad { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual League League { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }

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
