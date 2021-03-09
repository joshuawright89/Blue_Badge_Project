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
    public class AppUserDetail
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset? DateJoined { get; set; }


        public int WeightInLbs { get; set; }
        public int HeightInCentimeters { get; set; }

        public GenderEnum Gender { get; set; }
         
        public BodyTypeEnum BodyType { get; set; }
 
        public GoalEnum Goal { get; set; }
 
    }
}
