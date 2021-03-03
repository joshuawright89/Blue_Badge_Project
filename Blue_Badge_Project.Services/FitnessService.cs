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

        public FitnessService(int fitnessId)
        {
            _fitId = fitnessId;
        }


        public bool CreateFitness(FitnessCreate model)
        {
            var entity =
                new FitnessPlan()
                {
                    Name = model.Name,
                    FitnessDesc = model.FitnessDesc,
                    WeightLoss = model.WeightLoss,
                    MuscleGain = model.MuscleGain,
                    Endurance = model.Endurance,
                    FitnessRestrictions = model.FitnessRestrictions,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FitPlans.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        public FitnessDetail GetFitnessById(int fitnessId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitPlans
                    .Single(e => e.fitId == _fitId);
                return
                   new FitnessDetail
                   {
                       Name = entity.Name,
                       FitnessDesc = entity.FitnessDesc,
                       WeightLoss = entity.WeightLoss,
                       MuscleGain = entity.MuscleGain,
                       Endurance = entity.Endurance,
                       FitnessRestrictions = entity.FitnessRestrictions,
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
                    .FitPlans
                    .Single(e => e.fitId == _fitId);
                    
                entity.Name = model.Name;
                entity.FitnessDesc = model.FitnessDesc;
                entity.WeightLoss = model.WeightLoss;
                entity.MuscleGain = model.MuscleGain;
                entity.Endurance = model.Endurance;
                entity.FitnessRestrictions = model.FitnessRestriction;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() > 0;
            }
        }
        public bool DeleteFitness(int fitnessId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitPlans
                    .Single(e => e.fitId == _fitId);

                ctx.FitPlans.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        public IEnumerable<FitnessListItem> GetFitness()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FitPlans
                        .Where(e => e.fitId == _fitId)
                        .Select(
                        e =>
                        new FitnessListItem
                        {
                            FitnessId = e.fitId,
                            Name = e.Name,
                            FitDesc = e.FitnessDesc,
                            CreatedUtc = e.CreatedUtc,
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
