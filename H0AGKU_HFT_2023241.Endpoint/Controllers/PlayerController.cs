using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController:ControllerBase
    {
        IPlayerLogic playerlogic;

        

        public PlayerController(IPlayerLogic logic)
        {
            this.playerlogic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Player value)
        {
            this.playerlogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.playerlogic.Delete(id);
        }
    }
}
