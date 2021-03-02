using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class DietListItem
    {
        public int DietId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string DietDesc { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
