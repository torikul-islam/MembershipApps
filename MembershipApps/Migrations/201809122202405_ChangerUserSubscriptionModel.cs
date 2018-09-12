namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangerUserSubscriptionModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserSubscriptions");
            AddColumn("dbo.UserSubscriptions", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserSubscriptions", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserSubscriptions");
            DropColumn("dbo.UserSubscriptions", "Id");
            AddPrimaryKey("dbo.UserSubscriptions", new[] { "SubscriptionId", "UserId" });
        }
    }
}
