﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    class SystemPlanListItem
    {
        public int SystemPlanId { get; set; }
        public double StartingWeight { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public string SystemPlanGoal { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [Display(Name = "Created")]
    }

}