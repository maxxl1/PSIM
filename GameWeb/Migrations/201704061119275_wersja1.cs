namespace GameWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wersja1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Marks", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Posts", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Marks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropIndex("dbo.Marks", new[] { "Game_Id" });
            DropIndex("dbo.Marks", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Game_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            AlterColumn("dbo.Marks", "Game_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Marks", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Game_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Marks", "Game_Id");
            CreateIndex("dbo.Marks", "User_Id");
            CreateIndex("dbo.Posts", "Game_Id");
            CreateIndex("dbo.Posts", "User_Id");
            AddForeignKey("dbo.Marks", "Game_Id", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Game_Id", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Marks", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Marks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Marks", "Game_Id", "dbo.Games");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Game_Id" });
            DropIndex("dbo.Marks", new[] { "User_Id" });
            DropIndex("dbo.Marks", new[] { "Game_Id" });
            AlterColumn("dbo.Posts", "User_Id", c => c.Int());
            AlterColumn("dbo.Posts", "Game_Id", c => c.Int());
            AlterColumn("dbo.Posts", "Text", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Marks", "User_Id", c => c.Int());
            AlterColumn("dbo.Marks", "Game_Id", c => c.Int());
            CreateIndex("dbo.Posts", "User_Id");
            CreateIndex("dbo.Posts", "Game_Id");
            CreateIndex("dbo.Marks", "User_Id");
            CreateIndex("dbo.Marks", "Game_Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Marks", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Posts", "Game_Id", "dbo.Games", "Id");
            AddForeignKey("dbo.Marks", "Game_Id", "dbo.Games", "Id");
        }
    }
}
