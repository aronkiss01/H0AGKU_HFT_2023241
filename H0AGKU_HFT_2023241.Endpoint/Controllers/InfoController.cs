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

        IPlayerLogic ipl;
        ITeamLogic itl;
        public InfoController(IPlayerLogic ipl, ITeamLogic itl)
        {
            this.ipl = ipl;
            this.itl = itl;
        }
        [HttpGet("{age}")]
        public IEnumerable<Player> GetPlayersYoungerThanX(int age)
        {
            return this.ipl.GetPlayersYoungerThanX(age);
        }
        [HttpGet]
        public int GetYoungsterSalaryInfo()
        {
            return this.ipl.GetYoungsterSalaryInfo();
        }
        [HttpGet]
        public int GetYoungestPlayerAge()
        {
            return this.ipl.GetYoungestPlayerAge();
        }
        [HttpGet("{tsId}")]
        public double AverageSalary(int tsId)
        {
            return this.itl.GetAverageSalaryInTeam(tsId);
        }
    }
}
