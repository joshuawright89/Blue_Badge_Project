using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class FitnessCreate
    {
        public string Name { get; set; }
        public string FitDescription { get; set; }
        public bool WeightLoss { get; set; }
        public bool MuscleGain { get; set; }
        public bool Endurance { get; set; }
        public RestrictionsEnum Restrictions { get; set; }
    }
}
