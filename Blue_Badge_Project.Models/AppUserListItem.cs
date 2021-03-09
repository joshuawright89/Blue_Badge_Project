using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blue_Badge_Project.Data.ApplicationUser;

namespace Blue_Badge_Project.Models
{
   
    public class AppUserListItem 
    {
        [Display(Name = "ID:")]
        public string UserId { get; set; }
        
        [Display(Name = "First:")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last:")]
        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        
        [Display(Name = "Gender:")]        
        public GenderEnum Gender { get; set; }

        [Display(Name = "Body Type")]
        public BodyTypeEnum BodyType { get; set; }

        [Display(Name = "Goal:")]
        public GoalEnum Goal { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset? DateJoined { get; set; }
    }
}
