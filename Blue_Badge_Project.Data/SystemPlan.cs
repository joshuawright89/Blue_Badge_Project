using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Data
{
    class SystemPlan
    {
        [Key]
        public int SystemPlanId { get; set; }
        //[ForeignKey]
        public int UserId { get; set; }
        //[ForeignKey]
        public int FitnessId { get; set; }
        //[ForeignKey]
        public int DietId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlanGoal { get; set; }
    }
}
