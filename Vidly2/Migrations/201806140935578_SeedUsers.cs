namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'6e64243a-92f6-4d1e-8820-d18ad7ec43e0', N'admin@vidly.com', 0, N'AGNhdrrfVynuJLUqM9qxPieS6+ASzt3qiSrtESuJCV8CHde91DwGaJwLNlVG+SbFjQ==', N'e761cbed-e297-4e45-be3e-70d0274991ef', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'8a38786d-9887-422b-95cf-26676b48b51e', N'guest@vidly.com', 0, N'AHgZ4lIAlc0B9Nu0e649FOKVbRnIFd4ltfvxTZvQmYawbcIe4KY1R5dWXEq7TTenTg==', N'79f956cb-8520-4daf-9a00-7d2f2b5fa128', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'febbc4e0-b38e-4562-8bec-db626bd0e059', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6e64243a-92f6-4d1e-8820-d18ad7ec43e0', N'febbc4e0-b38e-4562-8bec-db626bd0e059')"
            );
        }
        
        public override void Down()
        {

        }
    }
}
