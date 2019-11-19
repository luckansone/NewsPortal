namespace NewsPortal.Business.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        News_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.News_Id)
                .Index(t => t.News_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "News_Id", "dbo.News");
            DropForeignKey("dbo.News", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Tags", new[] { "News_Id" });
            DropIndex("dbo.News", new[] { "Category_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.News");
            DropTable("dbo.Categories");
        }
    }
}
