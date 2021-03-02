using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Badge_Project.Data
{
    public class AppUser
    {
        [Key]
        public int AppUserId { get; set; } 
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public int Age { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateJoined { get; set; }


        public int WeightInLbs { get; set; }
        public int HeightInCentimeters { get; set; }

        public GenderEnum Gender { get; set; }
        /// 
        /// Female = 1,
        /// Male
        /// 
        public BodyTypeEnum BodyType { get; set; }
        /// 
        /// Ectomorph = 1,
        /// Mesomorph,
        /// Endomorph
        /// 
        public GoalEnum Goal { get; set; }
        ///
        /// Gain Mass = 1,
        /// Lean down,
        /// Tone muscle,
        /// 
    }
    

    //Should the enums be elsewhere??  Hm...
    public enum GenderEnum
    {
        [Display(Name = "Female")]
        Female = 1,
        [Display(Name = "Male")]
        Male
    }

    public enum BodyTypeEnum
    {
        [Display(Name = "Ectomorph")]
        Ectomorph = 1,
        [Display(Name = "Mesomorph")]
        Mesomorph,
        [Display(Name = "Endomorph")]
        Endomorph
    }

    public enum GoalEnum
    {
        [Display(Name = "Gain mass")]
        GainMass = 1,
        [Display(Name = "Lean Down")]
        LeanDown,
        [Display(Name = "Tone muscle")]
        ToneMuscle
    }

}
