namespace GameWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Averge = c.Double(nullable: false),
                        Genre = c.String(),
                        Platform = c.String(),
                        Photo = c.String(),
                        Studio = c.String(),
                        Publisher = c.String(),
                        MinAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkValue = c.Double(nullable: false),
                        Game_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 450),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        City = c.String(),
                        Age = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Email = c.String(),
                        PhotoURl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Game_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Marks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Marks", "Game_Id", "dbo.Games");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Game_Id" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Marks", new[] { "User_Id" });
            DropIndex("dbo.Marks", new[] { "Game_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Marks");
            DropTable("dbo.Games");
        }
    }
}
