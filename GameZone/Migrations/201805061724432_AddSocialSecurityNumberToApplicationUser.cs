namespace GameZone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocialSecurityNumberToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SocialSecurityNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SocialSecurityNumber");
        }
    }
}
