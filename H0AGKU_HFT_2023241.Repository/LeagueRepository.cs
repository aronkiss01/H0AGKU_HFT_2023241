﻿using H0AGKU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Repository
{
    public class LeagueRepository : Repository<League>, IRepository<League>
    {
        public LeagueRepository(IceHockeyDbContext ctx) : base(ctx) { }
        public override League Read(int id)
        {
            return this.ctx.Leagues.First(x => x.Id == id);
        }

        public override void Update(League item)
        {
            var old = Read(item.Id);
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
