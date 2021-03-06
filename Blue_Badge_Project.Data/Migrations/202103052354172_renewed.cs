namespace Blue_Badge_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renewed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietPlan",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                        DietDesc = c.String(nullable: false),
                        BalancedDiet = c.Boolean(nullable: false),
                        Protein = c.Boolean(nullable: false),
                        Vegatarian = c.Boolean(nullable: false),
                        Carbo = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        DietRestrictions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DietId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
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
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.FitnessPlan",
                c => new
                    {
                        FitId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                        FitDescription = c.String(nullable: false),
                        WeightLoss = c.Boolean(nullable: false),
                        MuscleGain = c.Boolean(nullable: false),
                        Endurance = c.Boolean(nullable: false),
                        Restrictions = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.FitId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemPlan",
                c => new
                    {
                        SysId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FitId = c.Int(nullable: false),
                        DietId = c.Int(nullable: false),
                        PlanGoal = c.String(nullable: false),
                        StartingWeight = c.Double(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SysId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.DietPlan", t => t.DietId, cascadeDelete: true)
                .ForeignKey("dbo.FitnessPlan", t => t.FitId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FitId)
                .Index(t => t.DietId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemPlan", "FitId", "dbo.FitnessPlan");
            DropForeignKey("dbo.SystemPlan", "DietId", "dbo.DietPlan");
            DropForeignKey("dbo.SystemPlan", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.FitnessPlan", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.DietPlan", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.SystemPlan", new[] { "DietId" });
            DropIndex("dbo.SystemPlan", new[] { "FitId" });
            DropIndex("dbo.SystemPlan", new[] { "UserId" });
            DropIndex("dbo.FitnessPlan", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.DietPlan", new[] { "UserId" });
            DropTable("dbo.SystemPlan");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.FitnessPlan");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.DietPlan");
        }
    }
}
