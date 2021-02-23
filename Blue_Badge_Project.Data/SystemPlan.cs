using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Data
{
    public class SystemPlan
    {
        [Key]
        public int SystemPlanId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public int ApplicationUserId { get; set; }

        public virtual ApplicationUserId ApplicationUserId{ get; set; }

        [ForeignKey(nameof(FitnessPlan))]
        public int FitnessPlanId { get; set; }

        public virtual FitnessPlanId FitnessPlanId { get; set; }

        [ForeignKey(nameof(DietPlan))]
        public int DietPlanId { get; set; }

        public virtual DietPlanId DietPlanId { get; set; }


        [Required, Range(85, 400)]
        public double StartingWeight { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string SystemPlanGoal { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
