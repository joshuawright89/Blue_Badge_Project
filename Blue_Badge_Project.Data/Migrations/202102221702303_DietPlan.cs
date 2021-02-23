namespace Blue_Badge_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DietPlan : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DietPlan");
        }
    }
}
