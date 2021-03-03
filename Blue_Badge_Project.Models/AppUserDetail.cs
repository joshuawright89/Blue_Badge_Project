using System;
using System.ComponentModel.DataAnnotations;

namespace Blue_Badge_Project.Models
{
    public class AppUserDetail
    {
        public int AppUserId { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
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
}
