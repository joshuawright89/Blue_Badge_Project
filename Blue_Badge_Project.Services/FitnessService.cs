using Blue_Badge_Project.Data;
using Blue_Badge_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Services
{
    public class FitnessService 
    {
        private readonly string _userId;

        public FitnessService(string userId)
        {
            _userId = userId;
        }


        public bool CreateFitness(FitnessCreate model)
        {
            var entity =
                new FitnessPlan()
                {
                    UserId = _userId,
                    Name = model.Name,
                    FitDescription = model.FitDescription,
                    WeightLoss = model.WeightLoss,
                    MuscleGain = model.MuscleGain,
                    Endurance = model.Endurance,
                    Restrictions = model.Restrictions,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FitnessPlan.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public FitnessDetail GetFitnessById(int fitId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessPlan
                    .SingleOrDefault(e => e.FitId == fitId);
                return
                   new FitnessDetail
                   {
                       Name = entity.Name,
                       FitDescription = entity.FitDescription,
                       WeightLoss = entity.WeightLoss,
                       MuscleGain = entity.MuscleGain,
                       Endurance = entity.Endurance,
                       Restrictions = entity.Restrictions,
                       CreatedUtc = DateTimeOffset.Now

                   };
            }
        }


        public bool UpdateFitness(FitnessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessPlan
                    .SingleOrDefault(e => e.FitId == model.FitId && e.UserId == _userId);
                    
                entity.Name = model.Name;
                entity.FitDescription = model.FitDescription;
                entity.WeightLoss = model.WeightLoss;
                entity.MuscleGain = model.MuscleGain;
                entity.Endurance = model.Endurance;
                entity.Restrictions = (RestrictionsEnum) model.Restrictions;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteFitness(int fitId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessPlan
                    .SingleOrDefault(e => e.FitId == fitId);

                ctx.FitnessPlan.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<FitnessListItem> GetFitness()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FitnessPlan
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                        new FitnessListItem
                        {
                            FitId = e.FitId,
                            Name = e.Name,
                            FitDescription = e.FitDescription,
                            CreatedUtc = e.CreatedUtc,
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
