namespace Blue_Badge_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SystemPlan", name: "UserId", newName: "Id");
            RenameIndex(table: "dbo.SystemPlan", name: "IX_UserId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SystemPlan", name: "IX_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.SystemPlan", name: "Id", newName: "UserId");
        }
    }
}
