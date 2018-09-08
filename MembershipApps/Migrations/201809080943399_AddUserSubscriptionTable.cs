namespace MembershipApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSubscriptionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSubscriptions",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SubscriptionId, t.UserId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSubscriptions");
        }
    }
}
