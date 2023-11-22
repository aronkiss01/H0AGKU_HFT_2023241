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
                new League(1, "Liga X", "USA", true),
                new League(2, "Liga Y", "USA", true),
                new League(3, "Liga Z", "USA", false)
            }.AsQueryable());
            leagueLogic = new LeagueLogic(mockLeagueRepository.Object);
        }
        [Test]
        public void CorrectCreateTest()
        {
            var cct = new League(4, " Liga", "USA", false);
            leagueLogic.Create(cct);
            mockLeagueRepository.Verify(x => x.Create(cct), Times.Once());
        }
        [Test]
        public void IncorrectCreateTest()
        {
            var ict = new League(-7, "Kalinka League", "Russia", false);
            try
            {
                leagueLogic.Create(ict);
            }
            catch (ArgumentException)
            {
            }
            mockLeagueRepository.Verify(x => x.Create(ict), Times.Never());
        }
        [Test]
        public void ReadLeagueTest()
        {
            try
            {

                leagueLogic.Read(2);
            }
            catch
            {

            }
            mockLeagueRepository.Verify(x=>x.Read(2), Times.Once());
        }
    }
}
