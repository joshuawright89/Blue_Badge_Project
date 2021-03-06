namespace Blue_Badge_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renewed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SystemPlan", "FitnessId", "dbo.FitnessPlan");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_UserId" });
            RenameColumn(table: "dbo.SystemPlan", name: "FitnessId", newName: "FitId");
            RenameColumn(table: "dbo.IdentityUserClaim", name: "ApplicationUser_UserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogin", name: "ApplicationUser_UserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserRole", name: "ApplicationUser_UserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.SystemPlan", name: "IX_FitnessId", newName: "IX_FitId");
            DropPrimaryKey("dbo.FitnessPlan");
            DropPrimaryKey("dbo.ApplicationUser");
            AddColumn("dbo.DietPlan", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.DietPlan", "DietRestrictions", c => c.Int(nullable: false));
            DropColumn("dbo.FitnessPlan", "FitnessId");
            AddColumn("dbo.FitnessPlan", "FitId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.FitnessPlan", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.FitnessPlan", "FitDescription", c => c.String(nullable: false));
            AddColumn("dbo.FitnessPlan", "Restrictions", c => c.Int(nullable: false));
            AddColumn("dbo.SystemPlan", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityUserRole", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ApplicationUser", "FirstName", c => c.String());
            AlterColumn("dbo.ApplicationUser", "LastName", c => c.String());
            AlterColumn("dbo.ApplicationUser", "Password", c => c.String());
            AlterColumn("dbo.ApplicationUser", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserClaim", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityUserLogin", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.FitnessPlan", "FitId");
            AddPrimaryKey("dbo.ApplicationUser", "Id");
            CreateIndex("dbo.DietPlan", "UserId");
            CreateIndex("dbo.IdentityUserClaim", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserLogin", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserRole", "ApplicationUser_Id");
            CreateIndex("dbo.FitnessPlan", "UserId");
            CreateIndex("dbo.SystemPlan", "UserId");
            AddForeignKey("dbo.DietPlan", "UserId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.FitnessPlan", "UserId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.SystemPlan", "UserId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.SystemPlan", "FitId", "dbo.FitnessPlan", "FitId", cascadeDelete: true);
            AddForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            DropColumn("dbo.DietPlan", "DietaryRestrictions");
            DropColumn("dbo.FitnessPlan", "FitnessDesc");
            DropColumn("dbo.FitnessPlan", "FitnessRestrictions");
            DropColumn("dbo.SystemPlan", "SystemPlanGoal");
            DropColumn("dbo.ApplicationUser", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SystemPlan", "SystemPlanGoal", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.FitnessPlan", "FitnessRestrictions", c => c.Int(nullable: false));
            AddColumn("dbo.FitnessPlan", "FitnessDesc", c => c.String(nullable: false));
            AddColumn("dbo.FitnessPlan", "FitnessId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.DietPlan", "DietaryRestrictions", c => c.Int(nullable: false));
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.SystemPlan", "FitId", "dbo.FitnessPlan");
            DropForeignKey("dbo.SystemPlan", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.FitnessPlan", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.DietPlan", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.SystemPlan", new[] { "UserId" });
            DropIndex("dbo.FitnessPlan", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.DietPlan", new[] { "UserId" });
            DropPrimaryKey("dbo.ApplicationUser");
            DropPrimaryKey("dbo.FitnessPlan");
            AlterColumn("dbo.IdentityUserLogin", "ApplicationUser_Id", c => c.Int());
            AlterColumn("dbo.IdentityUserClaim", "ApplicationUser_Id", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "Id", c => c.String());
            AlterColumn("dbo.ApplicationUser", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.IdentityUserRole", "ApplicationUser_Id", c => c.Int());
            DropColumn("dbo.SystemPlan", "UserId");
            DropColumn("dbo.FitnessPlan", "Restrictions");
            DropColumn("dbo.FitnessPlan", "FitDescription");
            DropColumn("dbo.FitnessPlan", "UserId");
            DropColumn("dbo.FitnessPlan", "FitId");
            DropColumn("dbo.DietPlan", "DietRestrictions");
            DropColumn("dbo.DietPlan", "UserId");
            AddPrimaryKey("dbo.ApplicationUser", "UserId");
            AddPrimaryKey("dbo.FitnessPlan", "FitnessId");
            RenameIndex(table: "dbo.SystemPlan", name: "IX_FitId", newName: "IX_FitnessId");
            RenameColumn(table: "dbo.IdentityUserRole", name: "ApplicationUser_Id", newName: "ApplicationUser_UserId");
            RenameColumn(table: "dbo.IdentityUserLogin", name: "ApplicationUser_Id", newName: "ApplicationUser_UserId");
            RenameColumn(table: "dbo.IdentityUserClaim", name: "ApplicationUser_Id", newName: "ApplicationUser_UserId");
            RenameColumn(table: "dbo.SystemPlan", name: "FitId", newName: "FitnessId");
            CreateIndex("dbo.IdentityUserLogin", "ApplicationUser_UserId");
            CreateIndex("dbo.IdentityUserClaim", "ApplicationUser_UserId");
            CreateIndex("dbo.IdentityUserRole", "ApplicationUser_UserId");
            AddForeignKey("dbo.IdentityUserRole", "ApplicationUser_UserId", "dbo.ApplicationUser", "UserId");
            AddForeignKey("dbo.IdentityUserLogin", "ApplicationUser_UserId", "dbo.ApplicationUser", "UserId");
            AddForeignKey("dbo.IdentityUserClaim", "ApplicationUser_UserId", "dbo.ApplicationUser", "UserId");
            AddForeignKey("dbo.SystemPlan", "FitnessId", "dbo.FitnessPlan", "FitnessId", cascadeDelete: true);
        }
    }
}
