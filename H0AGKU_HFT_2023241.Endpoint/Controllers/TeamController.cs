using H0AGKU_HFT_2023241.Logic;
using H0AGKU_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace H0AGKU_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController: ControllerBase
    {
        ITeamLogic teamlogic;

        public TeamController(ITeamLogic teamLogic)
        {
            this.teamlogic = teamlogic;
        }
        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.teamlogic.ReadAll();
        }
        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return this.teamlogic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Team value)
        {
            this.teamlogic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Team value)
        {
            this.teamlogic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.teamlogic.Delete(id);
        }
    }
}
