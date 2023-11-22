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
    public class TeamTester
    {
        TeamLogic teamLogic;
        Mock<IRepository<Team>> mockTeamRepository;
        [SetUp]
        public void Init() 
        { 
            mockTeamRepository = new Mock<IRepository<Team>>();
            mockTeamRepository.Setup(x => x.ReadAll()).Returns(new List<Team>()
            {
                new Team(5,"Ice Bears",1,false),
                new Team(6,"Penguins LA",1,true),
                new Team(7,"Cold Snow",1, true)

            }.AsQueryable());
            teamLogic = new TeamLogic(mockTeamRepository.Object);

        }
        [Test]
        public void TeamCreateTest()
        {
            var tct=new Team(8,"Freezing Seals",1,false);
            teamLogic.Create(tct);
            mockTeamRepository.Verify(x => x.Create(tct), Times.Once());
        }
    }
}
