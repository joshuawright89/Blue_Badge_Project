using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{

    public enum DietRestrictions
    {
        Sugar = 1,
        Gluten,
        Carbs,
        NoRestrictions
    }

    public class DietCreate
    {
        
        public string Name { get; set; }
        public string DietDescription { get; set; }
        
        public bool BalancedDiet { get; set; }
        
        public bool Protein { get; set; }
        
        public bool Vegatarian { get; set; }
        
        public bool Carbo { get; set; }


        public DietRestrictions DietRestrictions { get; set; }

    }
}
