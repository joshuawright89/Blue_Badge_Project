namespace Blue_Badge_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restartMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietPlan",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DietDesc = c.String(nullable: false),
                        BalancedDiet = c.Boolean(nullable: false),
                        Protein = c.Boolean(nullable: false),
                        Vegatarian = c.Boolean(nullable: false),
                        Carbo = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        DietaryRestrictions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DietId);
            
            CreateTable(
                "dbo.FitnessPlan",
                c => new
                    {
                        FitnessId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FitnessDesc = c.String(nullable: false),
                        WeightLoss = c.Boolean(nullable: false),
                        MuscleGain = c.Boolean(nullable: false),
                        Endurance = c.Boolean(nullable: false),
                        FitnessRestrictions = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.FitnessId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_UserId);
            
            CreateTable(
                "dbo.SystemPlan",
                c => new
                    {
                        SysId = c.Int(nullable: false, identity: true),
                        FitnessId = c.Int(nullable: false),
                        DietId = c.Int(nullable: false),
                        PlanGoal = c.String(nullable: false),
                        StartingWeight = c.Double(nullable: false),
                        SystemPlanGoal = c.String(nullable: false, maxLength: 200),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SysId)
                .ForeignKey("dbo.DietPlan", t => t.DietId, cascadeDelete: true)
                .ForeignKey("dbo.FitnessPlan", t => t.FitnessId, cascadeDelete: true)
                .Index(t => t.FitnessId)
                .Index(t => t.DietId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                        WeightInLbs = c.Int(nullable: false),
                        HeightInCentimeters = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Goal = c.Int(nullable: false),
                        BodyType = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .Index(t => t.ApplicationUser_UserId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .Index(t => t.ApplicationUser_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.SystemPlan", "FitnessId", "dbo.FitnessPlan");
            DropForeignKey("dbo.SystemPlan", "DietId", "dbo.DietPlan");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.SystemPlan", new[] { "DietId" });
            DropIndex("dbo.SystemPlan", new[] { "FitnessId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.SystemPlan");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.FitnessPlan");
            DropTable("dbo.DietPlan");
        }
    }
}
