using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    class SystemPlanCreate
    {
        [Required, Range(85, 400)]
        public double StartingWeight { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string SystemPlanGoal { get; set; }
    }
}
