using Blue_Badge_Project.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blue_Badge_Project.Models
{

    public class AppUserCreate 
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        
        public GenderEnum Gender { get; set; }

        public GoalEnum Goal { get; set; }

        public BodyTypeEnum BodyType { get; set; }

        

    }
}