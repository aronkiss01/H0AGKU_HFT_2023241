using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public string Position { get; set; }
        public int PlayerSalary { get; set; }
        public bool FieldPStick { get; set; }

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
