namespace NewsPortal.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifycontext : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TagModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
