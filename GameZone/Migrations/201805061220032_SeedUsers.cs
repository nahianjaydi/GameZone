namespace GameZone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a2ac0bc-904c-4e98-b890-4b18d92b4bf1', N'guest@gamezone.com', 0, N'AAKID5f3Az8vkiUQYnut1WZw5SKcF1B0dIodUrnBVC/jxwrTKIQRPp907cIAy986qg==', N'f38bfdda-e465-4deb-9297-88aa110b2b88', NULL, 0, 0, NULL, 1, 0, N'guest@gamezone.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6cc20369-798d-4130-aaad-f4e746cff1b1', N'admin@gamezone.com', 0, N'ACemwxf9aVzjo2PXV+x4kNr7Xx0rBKNZ7renbomyUWHjpHTV5mUG1dwvq953QauG8g==', N'4c1add50-7bc9-4dda-843a-4a2d22c1e044', NULL, 0, 0, NULL, 1, 0, N'admin@gamezone.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2130504f-9431-4b09-a324-43696e6f14d0', N'CanManageGames')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6cc20369-798d-4130-aaad-f4e746cff1b1', N'2130504f-9431-4b09-a324-43696e6f14d0')

");
        }
        
        public override void Down()
        {
        }
    }
}
