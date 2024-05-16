using H0AGKU_HFT_2023241.Endpoint.Services;
using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController:ControllerBase
    {
        IPlayerLogic playerlogic;
        IHubContext<SignalRHub> hub;



        public PlayerController(IPlayerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.playerlogic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return this.playerlogic.ReadAll();
        }

        [HttpGet("{id}")]       
        public Player Read(int id)
        {
            return this.playerlogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Player value)
        {
            this.playerlogic.Create(value);
            this.hub.Clients.All.SendAsync("PlayerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Player value)
        {
            this.playerlogic.Update(value);
            this.hub.Clients.All.SendAsync("PlayerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var PlayerDelete=this.playerlogic.Read(id);
            this.playerlogic.Delete(id);
            this.hub.Clients.All.SendAsync("PlayerDeleted", PlayerDelete);
        }
    }
}
