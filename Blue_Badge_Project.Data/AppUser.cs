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
        public string AppUserId { get; set; }
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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateJoined { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Weight { get; set; }
        public int Height { get; set; }

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
        Female = 1,
        Male
    }

    public enum BodyTypeEnum
    {
        Ectomorph = 1,
        Mesomorph,
        Endomorph
    }

    public enum GoalEnum
    {
        GainMass = 1,
        LeanDown,
        ToneMuscle
    }

}
