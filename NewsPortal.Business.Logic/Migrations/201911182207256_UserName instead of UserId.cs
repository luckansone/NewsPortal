namespace NewsPortal.Business.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameinsteadofUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "UserName", c => c.String());
            DropColumn("dbo.News", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "UserId", c => c.String());
            DropColumn("dbo.News", "UserName");
        }
    }
}
