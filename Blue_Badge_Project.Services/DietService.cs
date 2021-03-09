using Blue_Badge_Project.Models;
using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Services
{
    public class DietService
    {
        //private readonly int _dietId;

        private readonly string _userId;

            public DietService(string userId)
            {
                _userId = userId;
            }
            public bool CreateDiet(DietCreate model)
        {
            var entity =
                new DietPlan()
                {
                    Name = model.Name,
                    DietDescription = model.DietDescription,
                    BalancedDiet = model.BalancedDiet,
                    Protein = model.Protein,
                    Vegatarian = model.Vegatarian,
                    Carbo = model.Carbo,
                    DietRestrictions = (DietRestriction) model.DietRestrictions,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.DietPlan.Add(entity);
                return ctx.SaveChanges() > 1;
            }
        }
        public DietDetail GetDietById(int DietId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DietPlan
                    .Single(e => e.DietId == DietId);
                return 
                    new DietDetail
                    {
                        Name = entity.Name,
                        DietDescription = entity.DietDescription,
                        BalancedDiet = entity.BalancedDiet,
                        Protein = entity.Protein,
                        Vegatarian = entity.Vegatarian,
                        Carbo = entity.Carbo,
                        DietRestrictions = (DietRestriction) entity.DietRestrictions,
                        CreatedUtc = DateTimeOffset.Now
                    };
            }
        }
   
        public bool UpdateDiet(DietEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DietPlan
                    .Single(e => e.DietId == e.DietId);

                entity.Name = model.Name;
                entity.DietDescription = model.DietDescription;
                entity.BalancedDiet = model.BalancedDiet;
                entity.Protein = model.Protein;
                entity.Vegatarian = model.Vegatarian;
                entity.Carbo = model.Carbo;
                entity.DietRestrictions = (DietRestriction) model.DietRestrictions;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() > 1;
            }
        }

        public bool DeleteDiet(int dietId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DietPlan
                    .Single(e => e.DietId == dietId);

                ctx.DietPlan.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        // HELPER METHOD
        // SEE ALL NOTES FOR SPECIFIC USER
        public IEnumerable<DietListItem> GetDiets()
        {
           using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .DietPlan
                        .Where(e => e.UserId == _userId)

                        .Select(
                        e =>
                        new DietListItem
                        {
                            DietId = e.DietId,
                            Name = e.Name,
                            DietDescription = e.DietDescription,
                            CreatedUtc = e.CreatedUtc,
                            
                        }
                   );
                return query.ToArray();
            }
        }

    }
}
