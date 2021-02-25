using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Data
{
    public enum FitRestrictions
    {
        LowImpact = 1,
        Asthma,
        HighBloodPressure,
        NoRestrictions
    }
    public class FitnessPlan
    {
        [Key]
        public int FitnessId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool WeightLoss { get; set; }
        [Required]
        public bool MuscleGain { get; set; }
        [Required]
        public bool Endurance { get; set; }
        [Required]
        public FitRestrictions Restrictions { get; set; }
    }

}

