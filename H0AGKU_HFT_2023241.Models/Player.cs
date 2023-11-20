using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public int PlayerSalary { get; set; }
        public bool FieldPStick { get; set; }
        public string Position { get; set; }
        [ForeignKey(nameof(Team))]
        public int TeamID { get; set; }
        [NotMapped]
        public virtual Team Team { get; set; }
        public Player()
        {
            
        }
        public Player(string name, int id, int age, int playerSalary, bool fieldPStick, string position, int teamID)
        {
            Name = name;
            Id = id;
            Age = age;
            PlayerSalary = playerSalary;
            FieldPStick = fieldPStick;
            Position = position;
            TeamID = teamID;
            
        }
    }
}
