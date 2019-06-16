namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDriverLicenseToAppUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DriverLicense", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DriverLicense");
        }
    }
}
