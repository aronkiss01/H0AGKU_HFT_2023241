using H0AGKU_HFT_2023241.Models;
using System;

namespace H0AGKU_HFT_2023241.Client
{
    internal class Program
    {
        static RestService RestService;

        static void Main(string[] args)
        {

        }
        static void Create(string entity)
        {
            if (entity == "League")
            {
                Console.Write("League name: ");
                string Lname = Console.ReadLine();
                Console.Write("League country: ");
                string Lcountry = Console.ReadLine();
                Console.Write("League has VAR? (true/false): ");
                bool hasVar = bool.Parse(Console.ReadLine());
                RestService.Post(new League() {LeagueName = Lname, Country = Lcountry, HasVar = hasVar }, "league");

            }
            else if (entity == "Player")
            {
                Console.Write("Player name: ");
                string Plname = Console.ReadLine();
                Console.Write("Player age: ");
                int PLage = int.Parse(Console.ReadLine());
                Console.Write("Player position: ");
                string Ppos = Console.ReadLine();
                Console.Write("Is player right footed?(true/false): ");
                bool FStick = bool.Parse(Console.ReadLine());
                Console.Write("Player salary: ");
                int Psalary = int.Parse(Console.ReadLine());
                Console.Write("Player team ID: ");
                int TeamId = int.Parse(Console.ReadLine());
                RestService.Post(new Player() {Name=Plname,Age=PLage,Position=Ppos,FieldPStick=FStick,PlayerSalary=Psalary,TeamID=TeamId },"player");
            }
            else if (entity == "Team")
            {
                Console.Write("Team name: ");
                string Tname = Console.ReadLine();
                Console.Write("Team league ID: ");
                int TLId = int.Parse(Console.ReadLine());
                Console.Write("Team has youth squad?(true/false): ");
                bool juniorSquad = bool.Parse(Console.ReadLine());
                RestService.Post(new Team() { Name = Tname, LeagueID = TLId, HasJuniorSquad = juniorSquad }, "team");
            }
            Console.ReadLine();

        }
        static void Update(string entity)
        {
            if (entity == "League")
            {
                Console.WriteLine("Enter the League ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                League league = RestService.Get<League>(id, "league");
                Console.WriteLine($"Old name:{league.LeagueName} new name: ");
                string newName = Console.ReadLine();
                league.LeagueName = newName;
                RestService.Put(league, "league");

            }
            else if (entity == "Team")
            {
                Console.WriteLine("Team ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Team t = RestService.Get<Team>(id, "team");
                Console.WriteLine($"Old name:{t.Name} new name: ");
                string newName = Console.ReadLine();
                t.Name = newName;
                RestService.Put(t, "team");
            }
            else if (entity == "Player")
            {
                Console.WriteLine("Enter the Player ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Player p = RestService.Get<Player>(id, "player");
                Console.WriteLine($"Old name:{p.Name} new name: ");
                string newName = Console.ReadLine();
                p.Name = newName;
                RestService.Put(p, "player");
            }
        }
        
    }
}
