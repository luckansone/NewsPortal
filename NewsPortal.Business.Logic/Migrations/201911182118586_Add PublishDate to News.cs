namespace NewsPortal.Business.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublishDatetoNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "PublishTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "PublishTime");
        }
    }
}
