namespace NewsPortal.Business.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Tags", "News_Id", "dbo.News");
            DropIndex("dbo.News", new[] { "Category_Id" });
            DropIndex("dbo.Tags", new[] { "News_Id" });
            RenameColumn(table: "dbo.Tags", name: "News_Id", newName: "NewsId");
            AddColumn("dbo.News", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "NewsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tags", "NewsId");
            AddForeignKey("dbo.Tags", "NewsId", "dbo.News", "Id", cascadeDelete: true);
            DropColumn("dbo.News", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Category_Id", c => c.Int());
            DropForeignKey("dbo.Tags", "NewsId", "dbo.News");
            DropIndex("dbo.Tags", new[] { "NewsId" });
            AlterColumn("dbo.Tags", "NewsId", c => c.Int());
            DropColumn("dbo.News", "CategoryId");
            RenameColumn(table: "dbo.Tags", name: "NewsId", newName: "News_Id");
            CreateIndex("dbo.Tags", "News_Id");
            CreateIndex("dbo.News", "Category_Id");
            AddForeignKey("dbo.Tags", "News_Id", "dbo.News", "Id");
            AddForeignKey("dbo.News", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
