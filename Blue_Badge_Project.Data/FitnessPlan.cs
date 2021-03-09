using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Data
{
    public enum RestrictionsEnum
    {
        LowImpact = 1,
        Asthma,
        HighBloodPressure,
        NoRestrictions
    }
    public class FitnessPlan
    {
        [Key]
        public int FitId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FitDescription { get; set; }
        [Required]
        public bool WeightLoss { get; set; }
        [Required]
        public bool MuscleGain { get; set; }
        [Required]
        public bool Endurance { get; set; }
        [Required]
        public RestrictionsEnum Restrictions { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
