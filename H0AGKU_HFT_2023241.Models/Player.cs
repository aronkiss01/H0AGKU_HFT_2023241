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
        public int Age { get; set; }
        public int PlayerSalary { get; set; }
        public bool FieldPStick { get; set; }
        public string Position { get; set; }
        [ForeignKey(nameof(Team))]
        public int ID { get; set; }
        [NotMapped]
        public virtual Team Team { get; set; }
        public Player()
        {
            
        }
        public Player(string name, int age, int iD, string position, int playerSalary, bool fieldPStick)
        {
            Name = name;
            Age = age;
            ID = iD;
            Position = position;
            PlayerSalary = playerSalary;
            FieldPStick = fieldPStick;
        }
    }
}
