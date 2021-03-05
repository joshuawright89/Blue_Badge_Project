using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class DietDetail
    {
        public int DietId { get; set; }
        public string Name { get; set; }
        public string DietDesc { get; set; }
        public bool BalancedDiet { get; set; }

        public bool Protein { get; set; }

        public bool Vegatarian { get; set; }

        public bool Carbo { get; set; }
        public DietRestrictions DietRestrictions { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
