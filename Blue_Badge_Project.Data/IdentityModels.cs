using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Blue_Badge_Project.Data
{
    public class ApplicationUser : IdentityUser
    {        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
           
            return userIdentity;
        }

        public enum GenderEnum
        {
            Female = 1,
            Male
        }

        public enum GoalEnum
        {
            GainMass = 1,
            LeanDown,
            ToneMuscle
        }

        public enum BodyTypeEnum
        {
            Ectomorph = 1,
            Mesomorph,
            Endomorph
        }

        
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string Password { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateJoined { get; set; }


        public int WeightInLbs { get; set; }
        public int HeightInCentimeters { get; set; }

        public GenderEnum Gender { get; set; }
        public GoalEnum Goal { get; set; }
        public BodyTypeEnum BodyType { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<DietPlan> DietPlan { get; set; }
        public DbSet<SystemPlan> SystemPlan { get; set; }
        public DbSet<FitnessPlan> FitnessPlan { get; set; }
    



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
            .Conventions
            .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
        
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(IdentityUserLogin => IdentityUserLogin.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}