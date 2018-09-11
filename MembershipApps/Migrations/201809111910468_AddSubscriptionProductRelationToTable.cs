namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscriptionProductRelationToTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SubscriptionProduct");
            AddColumn("dbo.SubscriptionProduct", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SubscriptionProduct", "Id");
            CreateIndex("dbo.SubscriptionProduct", "ProductId");
            CreateIndex("dbo.SubscriptionProduct", "SubscriptionId");
            AddForeignKey("dbo.SubscriptionProduct", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubscriptionProduct", "SubscriptionId", "dbo.Subscription", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubscriptionProduct", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.SubscriptionProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.SubscriptionProduct", new[] { "SubscriptionId" });
            DropIndex("dbo.SubscriptionProduct", new[] { "ProductId" });
            DropPrimaryKey("dbo.SubscriptionProduct");
            DropColumn("dbo.SubscriptionProduct", "Id");
            AddPrimaryKey("dbo.SubscriptionProduct", new[] { "ProductId", "SubscriptionId" });
        }
    }
}
