using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class SystemPlanListItems
    {
        public int SysId { get; set; }

        public int _userId { get; set; }

        public double StartingWeight { get; set; }

        public string PlanGoal { get; set; } //does this need to be an Diet/Fitness==or enum

    }
}
