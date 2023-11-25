using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeagueController:ControllerBase 
    {
        ILeagueLogic leaguelogic;

        public LeagueController(ILeagueLogic leaguelogic)
        {
            this.leaguelogic = leaguelogic;
        }
        [HttpGet]
        public IEnumerable<League> ReadAll()
        {
            return this.leaguelogic.ReadAll();
        }
        [HttpGet("{id}")]
        public League Read(int id) 
        { 
            return this.leaguelogic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] League value)
        {
            this.leaguelogic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] League value) 
        { 
            this.leaguelogic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            this.leaguelogic.Delete(id);
        }

    }
}
