using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using H0AGKU_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace H0AGKU_HFT_2023241.Test
{
    [TestFixture]
    public class LeagueTester
    {
        LeagueLogic leagueLogic;
        Mock<IRepository<League>> mockLeagueRepository;

        [SetUp]
        public void Init()
        {
            mockLeagueRepository = new Mock<IRepository<League>>();
            mockLeagueRepository.Setup(x => x.ReadAll()).Returns(new List<League>()
            {
                new League(10, "Liga X", "USA", true),
                new League(11, "Liga Y", "USA", true),
                new League(12, "Liga Z", "USA", false)
            }.AsQueryable());
            leagueLogic = new LeagueLogic(mockLeagueRepository.Object);
        }
        [Test]
        public void CorrectCreateTest() 
        {
            var cct = new League(13, " Liga", "USA", false);
            leagueLogic.Create(cct);
            mockLeagueRepository.Verify(a => a.Create(cct), Times.Once());
        }

    }
}
