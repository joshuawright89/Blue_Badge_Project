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
    //public enum Gender { Male, Female} // pay attention to where you define this: Data Layer? Service Layer, Model Layer? You want to define it once, and make appropriate references/using statements
    public class AppUserListItem //What properties to display when seeing a list of App Users??
    {
        [Display(Name = "User ID:")]
        public int AppUserId { get; set; }
        [Display(Name = "First:")]
        public string FirstName { get; set; }
        [Display(Name = "Last:")]
        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateJoined { get; set; }
        public int Age { get; set; }
        
        [Display(Name = "Gender:")]        
        public GenderEnum Gender { get; set; }
        [Display(Name = "Goal:")]
        public GoalEnum Goal { get; set; }
    }
}
