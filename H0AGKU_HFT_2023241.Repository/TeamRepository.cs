using H0AGKU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Repository
{
    public class TeamRepository : Repository<Team>, IRepository<Team>
    {
        public TeamRepository(IceHockeyDbContext ctx):base(ctx) { }               
        
        public override Team Read(int id)
        {
           return this.ctx.Teams.First(t=>t.ID==id);
        }

        public override void Update(Team item)
        {
            var old = Read(item.ID);
            foreach (var x in old.GetType().GetProperties())
            {
                if (x.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    x.SetValue(old, x.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
            
    }
}
