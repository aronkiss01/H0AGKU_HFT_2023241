using ConsoleTools;
using H0AGKU_HFT_2023241.Models;
using System;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Client
{
    internal class Program
    {
        static RestService RestService;

        static void Main(string[] args)
        {
            RestService = new RestService("http://localhost:62823/", "league");
            var leagueSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("League"))
                .Add("Create", () => Create("League"))
                .Add("Delete", () => Delete("League"))
                .Add("Update", () => Update("League"))
                .Add("Junior League Info", () => JuniorLeagueInfo("League"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Average salary", () => AverageSalary("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Younger than", () => YoungerThan("Player"))
                .Add("Young players salary info", () => YoungSalary("Player"))
                .Add("Youngest player age", () => YoungestPlayerAge("Player"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Leagues", () => leagueSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
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
                Console.Write("Does Player use FieldStick ? (true/false): ");
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
                Console.Write("Team has junior squad?(true/false): ");
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
        static void Delete(string entity)
        {
            if (entity == "League")
            {
                Console.WriteLine("League ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                RestService.Delete(id, "league");
            }
            else if (entity == "Team")
            {
                Console.WriteLine("Team ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                RestService.Delete(id, "team");
            }
            else if (entity == "Player")
            {
                Console.WriteLine("Player ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                RestService.Delete(id, "player");
            }
        }
        static void YoungerThan(string entity)
        {
            Console.WriteLine("Players under age: ");
            int age = int.Parse(Console.ReadLine());
            IEnumerable<Player> youngplayers = RestService.Get<Player>("Info/GetPlayersYoungerThanX/" + age);
            foreach (var item in youngplayers)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void YoungSalary(string entity)
        {
            int x = RestService.GetSingle<int>("Info/GetYoungsterSalaryInfo");
            Console.WriteLine("U20 Players salary sum: " + x);
            Console.ReadLine();
        }
        static void YoungestPlayerAge(string entity)
        {
            int x = RestService.GetSingle<int>("Info/GetYoungestPlayerAge");
            Console.WriteLine("The youngest player age is: " + x);
            Console.ReadLine();
        }
        static void AverageSalary(string entity)
        {
            Console.WriteLine("Team ID: ");
            int id = int.Parse(Console.ReadLine());
            double x = RestService.GetSingle<double>("Info/AverageSalary/" + id);
            Console.WriteLine(x);
            Console.ReadKey();
        }
        static void JuniorLeagueInfo(string entity)
        {
            var junior = RestService.Get<JuniorLeagueInfo>("JuniorLeague/GetJuniorLeagueInfo");
            foreach (var item in junior)
            {
                Console.WriteLine("League ID: " + item.LeagueId);
                Console.WriteLine("Junior Squad Counter: " + item.JuniorSquadsInLeague);
            }
            Console.ReadKey();
        }
        static void List(string entity)
        {
            if (entity == "League")
            {
                List<League> leagues = RestService.Get<League>("league");
                foreach (var item in leagues)
                {
                    Console.WriteLine("(" + item.Id + ")" + item.LeagueName);
                }
            }
            else if (entity == "Player")
            {
                List<Player> leagues = RestService.Get<Player>("player");
                foreach (var item in leagues)
                {
                    Console.WriteLine("(" + item.Id + ")" + item.Name);
                }
            }
            else if (entity == "Team")
            {
                List<Team> leagues = RestService.Get<Team>("team");
                foreach (var item in leagues)
                {
                    Console.WriteLine("(" + item.LeagueID + ")" + item.Name);
                }
            }
            Console.ReadLine();
        }

    }
}
