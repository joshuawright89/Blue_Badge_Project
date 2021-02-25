using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    //public enum Gender { Male, Female} // pay attention to where you define this: Data Layer? Service Layer, Model Layer? You want to define it once, and make appropriate references/using statements
    public class AppUserListItem //What properties to display when seeing a list of App Users??
    {
        public string AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateJoined { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        
                
        public GenderEnum Gender { get; set; }
        public GoalEnum Goal { get; set; }
    }
}
