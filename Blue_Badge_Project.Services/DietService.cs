using Blue_Badge_Project.Models;
using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Services
{
    class DietService
    {
        public bool CreateDiet(DietCreate model)
        {
            var entity =
                new DietPlan()
                {
                    Name = model.Name,
                    DietDesc = model.DietDesc,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.DietaryPlan.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        
    }
}
