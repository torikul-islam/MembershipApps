namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangerUserSubscriptionTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserSubscriptions");
            AddPrimaryKey("dbo.UserSubscriptions", new[] { "SubscriptionId", "UserId" });
            DropColumn("dbo.UserSubscriptions", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserSubscriptions", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserSubscriptions");
            AddPrimaryKey("dbo.UserSubscriptions", "Id");
        }
    }
}
