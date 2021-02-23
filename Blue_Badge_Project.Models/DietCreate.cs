using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class DietCreate
    {
        
        public string Name { get; set; }
        public string DietDesc { get; set; }
        
        public bool BalancedDiet { get; set; }
        
        public bool Protein { get; set; }
        
        public bool Vegatarian { get; set; }
        
        public bool Carbo { get; set; }
        public DietRestrictions DietaryRestrictions { get; set; }

    }
}
