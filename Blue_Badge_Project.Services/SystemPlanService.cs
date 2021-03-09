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
        private readonly string _userId;

        public SystemPlanService(string userId)
        {
            _userId = userId;
        }


        public bool CreateSystemPlan(SystemPlanCreate plan)
        {
            var entity =
                new SystemPlan()
                {
                    Id = _userId,
                    FitId = plan.FitId,
                    DietId = plan.DietId,
                    PlanGoal = plan.PlanGoal,
                    StartingWeight = plan.StartingWeight,
                    CreatedUtc = DateTimeOffset.Now,
                    ModifiedUtc = DateTime.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SystemPlan.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public SystemPlanDetail GetSysIdById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .SingleOrDefault(e => e.SysId == id);
                if (entity != null)
                {
                    return
                  new SystemPlanDetail
                  {
                      SysId = entity.SysId,
                      PlanGoal = entity.PlanGoal,
                      StartingWeight = entity.StartingWeight,
                      CreatedUtc = DateTimeOffset.Now
                  };
                }
                else
                {
                    return null;
                }


            }
        }


        public bool UpdatePlan(SystemPlanEdit plan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .SingleOrDefault(e => e.SysId == plan.SysId);

                if (entity != null)
                {
                    entity.PlanGoal = plan.PlanGoal;
                    entity.StartingWeight = plan.StartingWeight;
                    entity.ModifiedUtc = DateTimeOffset.UtcNow;
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }

            }
        }


        public bool DeletePlan(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .SingleOrDefault(e => e.SysId == id);

                ctx.SystemPlan.Remove(entity);
                return ctx.SaveChanges() == 0;
            }
        }

        public IEnumerable<SystemPlanListItems> GetSystemPlan()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SystemPlan
                        .Where(e => e.Id == _userId)

                        .Select(
                        e =>
                        new SystemPlanListItems
                        {
                            SysId = e.SysId,
                            PlanGoal = e.PlanGoal,
                            StartingWeight = e.StartingWeight,


                        }
                   );
                return query.ToArray();
            }
        }
    }
}


