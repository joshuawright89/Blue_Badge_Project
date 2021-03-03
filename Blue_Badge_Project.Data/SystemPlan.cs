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

        //[Required]
        //public string Name { get; set; } //Not is the ProjectWireFrame

        //[ForeignKey(nameof(UseId))]
        // public Guid UserId { get; set; }

        // public virtual AppUser AppUser{ get; set; }

        [ForeignKey(nameof(FitnessPlan))]
        public int FitnessId { get; set; }
        public virtual FitnessPlan FitnessPlan { get; set; }

        [ForeignKey(nameof(DietPlan))]
        public int DietId { get; set; }

        public virtual DietPlan DietPlan{ get; set; }


        [Required]
        public string PlanGoal { get; set; }

        [Required, Range(85, 400)]
        public double StartingWeight { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string SystemPlanGoal { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
