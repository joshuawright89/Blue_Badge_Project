namespace Blue_Badge_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAppUserEdit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Password", c => c.String());
        }
    }
}
