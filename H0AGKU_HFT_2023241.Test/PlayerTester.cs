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
    public class PlayerTester
    {
        PlayerLogic playerLogic;
        Mock<IRepository<Player>> mockPlayerRepository;
        [SetUp]

        public void Init()
        {
            mockPlayerRepository = new Mock<IRepository<Player>>();
            playerLogic = new PlayerLogic(mockPlayerRepository.Object);
        }
        [Test]
        public void PlayerCreateTest()
        {
            var pct = new Player("Jimmy King",2,35,98000,false,"GoalTender",2);
            playerLogic.Create(pct);
            mockPlayerRepository.Verify(x =>x.Create(pct), Times.Once());
        }
        [Test]
        public void TestYoungestPlayer() 
        {
            mockPlayerRepository.Setup(x => x.ReadAll()).Returns(new List<Player>()
            {
                new Player("Paul Sonati",1,21,165000,true,"Midfilder",2),
                new Player("Cody Ice",2,32,216000,false,"GoalTender",2),
                new Player("Leslie Papasita",3,26,270000,true,"Midfilder",3),
                
                
            }.AsQueryable());
            playerLogic = new PlayerLogic(mockPlayerRepository.Object);
            Assert.AreEqual(playerLogic.GetYoungestPlayerAge(), 21);
        }


    }

}
