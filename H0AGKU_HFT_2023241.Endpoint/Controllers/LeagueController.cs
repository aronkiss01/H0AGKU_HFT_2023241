using H0AGKU_HFT_2023241.Endpoint.Services;
using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeagueController:ControllerBase 
    {
        ILeagueLogic leaguelogic;
        IHubContext<SignalRHub> hub;

        public LeagueController(ILeagueLogic logic, IHubContext<SignalRHub> hub)
        {
            this.leaguelogic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("LeagueCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] League value)
        {
            this.leaguelogic.Update(value);
            this.hub.Clients.All.SendAsync("LeagueUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var LeagueDelete = this.leaguelogic.Read(id);
            this.leaguelogic.Delete(id);           
            this.hub.Clients.All.SendAsync("LeagueDeleted", LeagueDelete);
        }

    }
}
