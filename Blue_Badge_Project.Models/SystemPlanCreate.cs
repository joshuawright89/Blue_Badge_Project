using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
   /* public enum PlanGoal
    {
        LooseWeight = 1,
        GainMuscleMass,
        BecomeHealthly,
        NoRestrictions
    }*/

    public class SystemPlanCreate
    {
        public int SysId { get; set; }

        [Required]
        [Range(85, 400)]
        public double StartingWeight { get; set; }

        public string PlanGoal { get; set; }
    }
}
