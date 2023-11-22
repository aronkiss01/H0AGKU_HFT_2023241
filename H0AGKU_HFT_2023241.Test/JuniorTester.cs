using Castle.Components.DictionaryAdapter.Xml;
using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using H0AGKU_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Test
{
    [TestFixture]
    public class JuniorTester
    {
        TeamLogic teamlogic;
        LeagueLogic leaguelogic;
        PlayerLogic playerlogic;
        Mock<IRepository<Team>> mockTeamRepository;
        Mock<IRepository<League>> mockLeagueRepository;
        Mock<IRepository<Player>> mockPlayerRepository;
        JuniorLeagueInfo juniorleagueinfo;


        [SetUp]
        public void Init()
        {
            mockTeamRepository = new Mock<IRepository<Team>>();
            mockLeagueRepository = new Mock<IRepository<League>>();
            mockPlayerRepository = new Mock<IRepository<Player>>();
            mockTeamRepository.Setup(t => t.ReadAll()).Returns(new List<Team>()
            {
                new Team(10,"Russian Winter",1,true),
                new Team(11,"Ice Bears",1,false),
                new Team(12,"Penguins LA",1,true),
                new Team(11,"Bohem Skaters",2,false),
            }.AsQueryable());
            mockLeagueRepository.Setup(t => t.ReadAll()).Returns(new List<League>()
            {
                new League(1,"Carpathian League","Hungary",false),
                new League(2,"Weak League","Germany",true),
            }.AsQueryable());
            mockPlayerRepository.Setup(t => t.ReadAll()).Returns(new List<Player>()
            {
                new Player("Danial Cold",14,28,176000,true,"Midfilder",12),
                new Player("John Snow",15,34,197560,true,"Midfilder",12),
                new Player("Vlagyimir Freeze",16,22,152100,true,"Midfilder",12),
                
            }.AsQueryable());
            teamlogic = new TeamLogic(mockTeamRepository.Object);
            leaguelogic = new LeagueLogic(mockLeagueRepository.Object);
            playerlogic = new PlayerLogic(mockPlayerRepository.Object);
            juniorleagueinfo = new JuniorLeagueInfo(1, 1);
        }
        [Test]
        public void CorrectTestJunioLeague()
        {
            Assert.AreEqual(juniorleagueinfo.JuniorSquadsInLeague, 1);
        }
        [Test]
        public void IncorrectTestJuniorLeague()
        {
            Assert.AreNotEqual(juniorleagueinfo.JuniorSquadsInLeague, 3);
        }
        [Test]
        public void CorrectNameTest()
        {
            Assert.AreEqual(juniorleagueinfo.LeagueId, 1);
        }
        [Test]
        public void IncorrectNameTest()
        {
            Assert.AreNotEqual(juniorleagueinfo.LeagueId, 2);
        }

    }
}
