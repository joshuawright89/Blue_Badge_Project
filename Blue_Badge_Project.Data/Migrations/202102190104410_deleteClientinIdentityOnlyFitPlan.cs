namespace Blue_Badge_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteClientinIdentityOnlyFitPlan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FitnessPlan",
                c => new
                    {
                        FitnessId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        WeightLoss = c.Boolean(nullable: false),
                        MuscleGain = c.Boolean(nullable: false),
                        Endurance = c.Boolean(nullable: false),
                        Restrictions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FitnessId);
            
            DropTable("dbo.Client");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.FitnessPlan");
        }
    }
}
