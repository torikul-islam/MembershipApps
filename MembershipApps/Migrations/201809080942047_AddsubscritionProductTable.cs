namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsubscritionProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscriptionProduct",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        SubscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.SubscriptionId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubscriptionProduct");
        }
    }
}
