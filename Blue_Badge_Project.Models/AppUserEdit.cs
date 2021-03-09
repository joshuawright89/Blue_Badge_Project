using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{
    public class AppUserEdit
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
  
        public int Height { get; set; }
       
        public int Weight { get; set; }
     
        public DateTime? DateOfBirth { get; set; }

        public GenderEnum Gender { get; set; }

        public GoalEnum Goal { get; set; }

        public BodyTypeEnum BodyType { get; set; }
    }
}
