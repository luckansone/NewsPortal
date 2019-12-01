namespace NewsPortal.Business.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
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
                        UserName = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "NewsId", "dbo.News");
            DropForeignKey("dbo.News", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tags", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "CategoryId" });
            DropTable("dbo.Tags");
            DropTable("dbo.News");
            DropTable("dbo.Categories");
        }
    }
}
