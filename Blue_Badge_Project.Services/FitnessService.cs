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
        private readonly int _fitId;

        public FitnessService(int fitId)
        {
            _fitId = fitId;
        }


        public bool CreateFitness(FitnessCreate model)
        {
            var entity =
                new FitnessPlan()
                {
                    Name = model.Name,
                    FitDescription = model.FitDescription,
                    WeightLoss = model.WeightLoss,
                    MuscleGain = model.MuscleGain,
                    Endurance = model.Endurance,
                    Restrictions = (RestrictionsEnum) model.Restrictions,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FitnessPlan.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        public FitnessDetail GetFitnessById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessPlan
                    .Single(e => e.FitId == Id);
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
                    .Single(e => e.FitId == model.FitId);
                    
                entity.Name = model.Name;
                entity.FitDescription = model.FitDescription;
                entity.WeightLoss = model.WeightLoss;
                entity.MuscleGain = model.MuscleGain;
                entity.Endurance = model.Endurance;
                entity.Restrictions = (RestrictionsEnum) model.Restrictions;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() > 0;
            }
        }
        public bool Delete(int fitId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessPlan
                    .Single(e => e.FitId == _fitId);

                ctx.FitnessPlan.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        public IEnumerable<FitnessListItem> GetFitness()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FitnessPlan
                        .Where(e => e.FitId == _fitId)
                        .Select(
                        e =>
                        new FitnessListItem
                        {
                            FitnessId = e.FitId,
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
