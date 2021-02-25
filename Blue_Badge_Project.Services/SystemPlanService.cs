using Blue_Badge_Project.Data;
using Blue_Badge_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Services
    {
    public class SystemPlanService
    {
        private readonly Guid _userId;

        public SystemPlanService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSystemPlan(SystemPlanCreate plan)
        {
            var entity =
                new SystemPlan()
                {
                    //UserId = _userId,
                    FitnessId = _userId,
                    DietId = _userId,
                    //Name = plan.Name,
                    StartingWeight = plan.StartingWeight,
                    SystemPlanGoal = plan.PlanGoal,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SystemPlan.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        public SystemPlanDetail GetSysIdById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId == id); //UserId, FitnessId and DietId
                return
                   new SystemPlanDetail
                   {
                       SysId = entity.SysId,
                       //Name = entity.Name,
                       StartingWeight = entity.StartingWeight,
                       PlanGoal = entity.PlanGoal,
                       CreatedUtc = DateTimeOffset.Now
                   };
            }
        }
        public bool UpdatePlan(SystemPlanEdit plan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId == plan.SysId); //UserId, FitnessId and DietId

                //entity.Name = plan.Name;
                entity.StartingWeight = plan.StartingWeight;
                entity.PlanGoal = plan.PlanGoal;

                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() > 0;
            }
        }
        public bool DeletePlan(int planId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId == planId); //UserId, FitnessId and DietId

                ctx.SystemPlan.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}

