namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c977d9c7-5086-478b-9dbf-a4da65e7b05e', N'guess1@moviepp.com', 0, N'ADtThF48b/LK6qMliP2iBjnhaoSpX7WFMXYz0nXndZngqyekXB+qnre7UvbEwLPhxw==', N'efe9f78b-be9f-421c-b0b9-4fc296f6f57a', NULL, 0, 0, NULL, 1, 0, N'guess1@moviepp.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e5ee2364-4616-402a-995d-97c3ecef19f2', N'admin@gmail.com', 0, N'AAprTHQ/gHpuAPSfb1OCBbRtXhxBjBUhC7rrqcw6aj2Yt+oCW5Qc0XcBLjJWlTI9fQ==', N'44e1c8ac-80c8-460c-9cc5-bc80359a5a43', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'11c3f5ee-b14c-4d62-88ce-2c5a69cf8466', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e5ee2364-4616-402a-995d-97c3ecef19f2', N'11c3f5ee-b14c-4d62-88ce-2c5a69cf8466')

            ");
        }

        public override void Down()
        {
        }
    }
}
