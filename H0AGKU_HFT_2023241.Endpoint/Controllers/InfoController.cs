using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InfoController:ControllerBase
    {
        IPlayerLogic playerLogic;
        ITeamLogic teamlogic;

        public InfoController(IPlayerLogic playerLogic, ITeamLogic teamlogic)
        {
            this.playerLogic = playerLogic;
            this.teamlogic = teamlogic;
        }
        [HttpGet("{age}")]
        public IEnumerable<Player> GetPlayersYoungerThanX(int age)
        {
            return this.playerLogic.GetPlayersYoungerThanX(age);
        }
        [HttpGet]
        public int GetYoungsterSalaryInfo()
        {
            return this.playerLogic.GetYoungsterSalaryInfo();
        }
        [HttpGet]
        public int GetYoungestPlayerAge()
        {
            return this.playerLogic.GetYoungestPlayerAge();
        }
        [HttpGet("{id}")]
        public double GetAverageSalaryInTeam(int id)
        {
            return this.teamlogic.GetAverageSalaryInTeam(id);
        }
    }
}
