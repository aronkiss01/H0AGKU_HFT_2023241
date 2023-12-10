using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class JuniorLeagueController:ControllerBase
    {
        ILeagueLogic jjlogic;

        public JuniorLeagueController(ILeagueLogic jjlogic)
        {
            this.jjlogic = jjlogic;
        }

        [HttpGet]
        public IEnumerable<JuniorLeagueInfo> GetJuniorLeagueInfo()
        {
            return jjlogic.GetJuniorLeagueInfo();
        }
    }
}
