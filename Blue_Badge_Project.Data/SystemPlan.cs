using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Data
{
    public class SystemPlan
    {
        [Key]
        public int UseId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
