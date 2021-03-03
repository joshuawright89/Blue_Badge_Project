using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class FitnessEdit
    {
        public int FitId { get; set; }
        public string Name { get; set; }
        public string FitDescription { get; set; }
        public bool WeightLoss { get; set; }
        public bool MuscleGain { get; set; }
        public bool Endurance { get; set; }
        public RestrictionsEnum FitnessRestriction { get; set; }
 
    }
}
