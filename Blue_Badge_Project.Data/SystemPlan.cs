using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Data
{
   
    public class SystemPlan
    {
        [Key]
        public int SysId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser{ get; set; }


        [ForeignKey(nameof(FitnessPlan))]
        public int FitId { get; set; }
        public virtual FitnessPlan FitnessPlan { get; set; }


        [ForeignKey(nameof(DietPlan))]
        public int DietId { get; set; }

        public virtual DietPlan DietPlan{ get; set; }



        [Required]
        public string PlanGoal { get; set; }

        [Required]
        public double StartingWeight { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
