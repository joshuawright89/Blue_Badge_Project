using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class FitnessDetail
    {
        public int FitnessId { get; set; }
        public string Name { get; set; }
        public string FitnessDesc { get; set; }
        public bool WeightLoss { get; set; }
        public bool MuscleGain { get; set; }
        public bool Endurance { get; set; }
        public FitRestrictions FitnessRestrictions { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }



    }
}
}
