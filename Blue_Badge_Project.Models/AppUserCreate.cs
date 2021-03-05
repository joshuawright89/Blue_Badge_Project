using Blue_Badge_Project.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blue_Badge_Project.Models
{

    public class AppUserCreate 
    {
        //[Required]
        //[MaxLength(20, ErrorMessage = "Do not exceed twenty (20) characters.")]
        //public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }

        public GenderEnum Gender { get; set; }

        public GoalEnum Goal { get; set; }


        public BodyTypeEnum BodyType { get; set; }

    }
}