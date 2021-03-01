using Blue_Badge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Models
{

    //How do we make this work with the default register process?

    //[MinLength(3, ErrorMessage = "Please enter at least three (3) characters.")]
    //[MaxLength(2000, ErrorMessage = "Do not exceed 2,000 characters for this note's title.")]


    public class AppUserCreate //What properties do we need to GIVE when creating a new user?
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Do not exceed twenty (20) characters.")]
        public string AppUserId { get; set; }
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
        //public enum GenderEnum
        //{
        //    Female = 1,
        //    Male
        //}

        public GoalEnum Goal { get; set; }
        //public enum GoalEnum
        //{
        //    GainMass = 1,
        //    LeanDown,
        //    ToneMuscle
        //}

        public BodyTypeEnum? BodyType { get; set; }
        //public enum BodyTypeEnum
        //{
        //    Ectomorph = 1,
        //    Mesomorph,
        //    Endomorph
        //}


        //Do not need to GIVE it four properties: date joined, OwnerId(Guid), or password

    }
}